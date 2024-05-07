import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import {
  Article,
  OptionContainer,
  OptionContainerToTag,
  Tag,
  TagToOptionContainer,
  TopicNames,
} from "../../types";
import Container from "../../components/general/container";
import { CustomInput } from "../../components/general";

import classes from "./editArticle.module.css";
import { StyledSelect } from "../../components/general/styledSelect";
import Feed from "../../components/general/feed";
import api from "../../config/axios";
import { useAuth } from "../../auth";
import CustomDialog from "../../components/resume/customDialog/customDialog";
import { TagButton, TagItem } from "../../components/tagContainer/tag";
import MDEditor from "@uiw/react-md-editor";
import CustomBeatLoader from "../../components/beatLoader";

export default function EditArticlePage() {
  const { articleId } = useParams();
  const navigate = useNavigate();
  const { user } = useAuth();

  const [error, setError] = useState<string>();

  const [loading, setLoading] = useState<boolean>(true);
  const [article, setArticle] = useState<Article | null>(null);

  const [title, setTitle] = useState<string>("");
  const [text, setText] = useState<string>("");
  const [topic, setTopic] = useState<OptionContainer[]>([]);
  const topicOptions = Object.entries(TopicNames).map(([key, name]) => ({
    label: name,
    value: Number(key),
  }));

  console.log(topicOptions);

  const [tags, setTags] = useState<Tag[]>([]);

  const saveArticle = () => {
    const article = {
      id: articleId,
      title: title,
      text: text,
      topic: {
        id: topic[0].value,
        name: topic[0].label,
      },
      tags: tags,
    };

    api
      .put(`articles/${articleId}`, article)
      .then(() => navigate(`/articles/${articleId}`))
      .catch(() => setError("Возникла ошибка"));
  };

  const [openedModal, setOpenedModal] = useState<boolean>(false);
  const [modalError, setModalError] = useState<string>("");
  const [tagSearch, setTagSearch] = useState<string>("");
  const [avaliableOptions, setAvaliableOptions] = useState<OptionContainer[]>(
    [],
  );
  const [addedOptions, setAddedOptions] = useState<OptionContainer[]>([]);

  const onSearch = ({
    props,
    state,
    methods,
  }: {
    props: any;
    state: any;
    methods: any;
  }) => {
    console.log({ props, state, methods });

    setTagSearch(state.search);

    const regexp = new RegExp(methods.safeString(state.search), "i");
    return methods
      .sortBy()
      .filter((item: any) =>
        regexp.test(
          getByPath(item, props.searchBy) || getByPath(item, props.valueField),
        ),
      );
  };

  const addTag = () => {
    api
      .post("/articles/tags/new", {
        name: tagSearch,
      })
      .then((response) => {
        setTags([...tags, response.data]);
        setOpenedModal(false);
        setModalError("");
      })
      .catch(() => setModalError("такой тег уже есть"));
  };

  const addTagToTagList = () => {
    if (addedOptions.length == 0) {
      setModalError("пустое поле");
      return;
    }

    const newTag = OptionContainerToTag(addedOptions[0]);
    if (tags.some((t) => t.id == newTag.id)) {
      setModalError("нельзя добавить тег дважды");
      return;
    }
    setTags([...tags, newTag]);
    setOpenedModal(false);
    setModalError("");
    setAddedOptions([]);
  };

  useEffect(() => {
    api
      .get("/articles/tags" + (tagSearch ? `?name=${tagSearch}` : ""))
      .then((response) => {
        setAvaliableOptions(
          response.data.flatMap((item: Tag) => TagToOptionContainer(item)),
        );
      });
  }, [tagSearch]);

  useEffect(() => {
    setLoading(true);
    api
      .get(`articles/${articleId}`)
      .then((response) => {
        console.log(response.data);
        setArticle(response.data);
        setTitle(response.data.title);
        setText(response.data.text);
        setTopic([
          {
            label: response.data.topic.name,
            value: response.data.topic.id,
          },
        ]);
        setTags(response.data.tags);
      })
      .catch(() => setArticle(null))
      .finally(() => setLoading(false));
  }, []);

  if (user == null) navigate("/login");

  if (loading) return <CustomBeatLoader />;

  if (article == null)
    return (
      <Container>
        <h2>Статья не найдена</h2>
      </Container>
    );

  if (article.author.userName != user.userName)
    return (
      <Container>
        <h2>Вы не можете редактировать эту статью</h2>
      </Container>
    );

  return (
    <>
      <CustomDialog
        isOpen={openedModal}
        onRequestClose={() => {
          setOpenedModal(false);
          setAddedOptions([]);
          setTagSearch("");
        }}
      >
        <div style={{ display: "flex", flexDirection: "column", gap: "1rem" }}>
          <h3>Добавить тэг</h3>
          {modalError && <span className={classes.error}>{modalError}</span>}
          <div style={{ display: "flex", flexDirection: "row", gap: "1.5rem" }}>
            <StyledSelect
              style={{ width: "300px" }}
              create
              values={addedOptions}
              options={avaliableOptions}
              onCreateNew={addTag}
              onChange={(values: OptionContainer[]) => {
                console.log(values);
                setAddedOptions(values);
              }}
              searchFn={onSearch}
              name="default"
            />
            <button onClick={addTagToTagList}>добавить</button>
          </div>
        </div>
      </CustomDialog>

      <Feed style={{ paddingBottom: "1.5rem", width: "60vw" }}>
        <Container>
          <h2>Новая статья</h2>
          <div className={classes.verticalGroup}>
            {error != null && error != "" && (
              <span className={classes.error}>{error}</span>
            )}
            <CustomInput
              placeholder="заголовок"
              value={title}
              onChange={(e: any) => setTitle(e.target.value)}
            />
            <StyledSelect
              values={topic}
              options={topicOptions}
              onChange={(values: OptionContainer[]) => {
                console.log(values);
                setTopic(values);
              }}
            />
            <MDEditor
              data-color-mode="light"
              value={text}
              placeholder="Ваш текст"
              onChange={setText}
            />
            <div
              className={[classes.tagContainer, classes.upperBorderBlock].join(
                " ",
              )}
            >
              <h2>Тэги навыков</h2>
              <div
                style={{
                  display: "flex",
                  flexWrap: "wrap",
                  flexDirection: "row",
                  gap: "0.5rem",
                }}
              >
                {tags.flatMap((tag, index) => (
                  <TagItem
                    editable
                    onClick={() => {
                      const newArray = [...tags];
                      newArray.splice(index, 1);
                      setTags(newArray);
                    }}
                    key={`tag_item_${index}`}
                    tag={tag}
                  />
                ))}
                <TagButton onClick={() => setOpenedModal(true)} />
              </div>
            </div>
            <button onClick={saveArticle}>Сохранить</button>
          </div>
        </Container>
      </Feed>
    </>
  );
}

const getByPath = (object: any, path: any) => {
  if (!path) return;

  return path.split(".").reduce((acc: any, value: any) => acc[value], object);
};
