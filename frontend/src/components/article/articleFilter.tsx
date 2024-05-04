import { useEffect, useState } from "react";
import { Tag, TagOptionContainer, TagToOptionContainer,  } from '../../types'
import api from "../../config/axios";
import { useSearchParams } from "react-router-dom";
import Container from "../general/container";
import { StyledSelect } from "../general/styledSelect";

function ArticleFilter() {
  const [searchParams, setSearchParams] = useSearchParams();
  const [avaliableOptions, setAvaliableOptions] = useState<TagOptionContainer[]>([]);
  const [addedOptions, setAddedOptions] = useState<TagOptionContainer[]>([]);
  const [searchString, setSearchString] = useState<string>("");

  // inner function copy
  const onSearch = ({ props, state, methods }: { props: any, state: any, methods: any }) => {
    console.log({ props, state, methods });

    setSearchString(state.search);

    const regexp = new RegExp(methods.safeString(state.search), 'i');
    return methods
      .sortBy()
      .filter((item: any) =>
        regexp.test(getByPath(item, props.searchBy) || getByPath(item, props.valueField))
      );
  };


  useEffect(() => {
    api.get("/articles/tags" + (searchString ? `?name=${searchString}` : ''))
      .then(response => {
        setAvaliableOptions(response.data.flatMap((item: Tag) => TagToOptionContainer(item)))
      })
  }, [searchString]);

  useEffect(() => {
    let newSearchParams: { [param: string]: any } = {};
    if (searchParams.get("title")) newSearchParams["title"] = searchParams.get("title");
    if (addedOptions.length > 0)
      newSearchParams["tags"] = addedOptions.flatMap((item: TagOptionContainer) => item.value);
    setSearchParams(newSearchParams, { replace: true });
  }, [addedOptions]);

  return <Container>
    <h3>Искать по тэгам</h3>
    <StyledSelect
      multi
      values={addedOptions}
      options={avaliableOptions}
      onChange={(values: TagOptionContainer[]) => {
        console.log("!");
        console.log(values);
        setAddedOptions(values)
      }}
      searchFn={onSearch}
      name="default" />
  </Container>;
}

export default ArticleFilter;

export const getByPath = (object: any, path: any) => {
  if (!path) {
    return;
  }

  return path.split('.').reduce((acc: any, value: any) => acc[value], object);
};