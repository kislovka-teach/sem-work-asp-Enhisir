import { useEffect, useState } from "react";
import { Tag, OptionContainer, TagToOptionContainer,  } from '../../types'
import api from "../../config/axios";
import { useSearchParams } from "react-router-dom";
import Container from "../general/container";
import { StyledSelect } from "../general/styledSelect";

function ArticleFilter() {
  const [searchParams, setSearchParams] = useSearchParams();
  const [avaliableOptions, setAvaliableOptions] = useState<OptionContainer[]>([]);
  const [addedOptions, setAddedOptions] = useState<OptionContainer[]>([]);
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
    if (searchParams.get("search")) newSearchParams["search"] = searchParams.get("search");
    if (addedOptions.length > 0)
      newSearchParams["tags"] = addedOptions.flatMap((item: OptionContainer) => item.value);
    setSearchParams(newSearchParams, { replace: true });
  }, [addedOptions]);

  return <Container>
    <h2>Искать по тэгам</h2>
    <StyledSelect
      multi
      values={addedOptions}
      options={avaliableOptions}
      onChange={(values: OptionContainer[]) => {
        console.log("!");
        console.log(values);
        setAddedOptions(values)
      }}
      searchFn={onSearch}
      name="default" />
  </Container>;
}

export default ArticleFilter;

const getByPath = (object: any, path: any) => {
  if (!path) return;

  return path.split('.').reduce((acc: any, value: any) => acc[value], object);
};