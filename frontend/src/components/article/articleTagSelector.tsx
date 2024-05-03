import { useEffect, useState } from "react";
import Select from "react-dropdown-select";
import styled from '@emotion/styled';
import { Tag } from '../../types'
import api from "../../config/axios";
import { useSearchParams } from "react-router-dom";
import Container from "../container";

function ArticleTagSelector() {
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

type TagOptionContainer = {
  label: string,
  value: number
}

const TagToOptionContainer = (tag: Tag): TagOptionContainer => ({ label: tag.name, value: tag.id });

export default ArticleTagSelector;

const StyledSelect = styled(Select)`
  background-color: #FAFAFA;
  border-color: var(--border-color);
  color: #4A4A4A;

  .react-dropdown-select-clear,
  .react-dropdown-select-dropdown-handle {
    color: #4A4A4A;
  }

  .react-dropdown-select-option {
    
    padding: 0.25rem 0.5rem;
    border-radius: 0.5rem;
    background-color: var(--accent-color);
    color: #FFFFFF;
    font-weight: 600;
  }

  .react-dropdown-select-input {
    color: #4A4A4A;
  }

  .react-dropdown-select-dropdown {
    display: flex;
    flex-direction: column;
    overflow: auto;
    z-index: 9;

    position: absolute;
    left: 0;
    width: 100%;
    padding: 0;
    
    background-color: #FAFAFA;
    color: #4A4A4A !important;
    border: 1px solid var(--border-color);
    box-shadow: none;
  }

  .react-dropdown-select-item {
    color: #4A4A4A;
    border-bottom: 1px solid var(--border-color);
       
    :hover {
       color: black;
    }
  }

  .react-dropdown-select-item.react-dropdown-select-item-selected,
  .react-dropdown-select-item.react-dropdown-select-item-active {
    background: var(--accent-color);
    color: #fff;
    font-weight: bold;
  }
`;

export const getByPath = (object: any, path: any) => {
  if (!path) {
    return;
  }

  return path.split('.').reduce((acc: any, value: any) => acc[value], object);
};