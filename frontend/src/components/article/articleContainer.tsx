import Container from "../general/container";
import { Article } from "../../types";
import AuthorBlock from "../authorBlock";
import KarmaBlock from "../karma";
import { Link, useNavigate } from "react-router-dom";
import { TagItem } from "../tagContainer/tag";
import TopicSpan from "./topicSpan/topicSpan";
import MDEditor from "@uiw/react-md-editor";
import { useAuth } from "../../auth";

function ArticleContainer({
  article,
  isShort = false,
}: {
  article: Article;
  isShort?: boolean;
}) {
  const navigate = useNavigate();
  const { user } = useAuth();

  const canEdit = article.author.userName == user?.userName;

  return (
    <Container>
      <div
        style={{
          display: "flex",
          justifyContent: "space-between",
          gap: "0.5rem",
        }}
      >
        <AuthorBlock author={article.author} />
        {canEdit && (
          <button
            className="alternative"
            onClick={() => navigate(`/articles/${article.id}/edit`)}
          >
            редактировать
          </button>
        )}
      </div>

      {isShort ? (
        <Link to={`/articles/${article.id}`} className="altHref">
          <h2>{article.title}</h2>
        </Link>
      ) : (
        <h2>{article.title}</h2>
      )}
      {
        <div
          style={{
            display: "flex",
            flexWrap: "wrap",
            flexDirection: "row",
            gap: "0.5rem",
          }}
        >
          <TopicSpan topic={article.topic} />
          {article.tags.flatMap((tag, index) => (
            <TagItem key={`tag_item_${index}`} tag={tag} />
          ))}
        </div>
      }
      {!isShort && (
        <div data-color-mode="light">
          <MDEditor.Markdown
            source={article.text}
            style={{ whiteSpace: "pre-wrap" }}
          />
        </div>
      )}
      {/* <KarmaBlock points={article.karma} onDown={() => { }} onUp={() => { }} /> */}
    </Container>
  );
}

export default ArticleContainer;
