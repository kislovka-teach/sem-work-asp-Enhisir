import Select from "react-dropdown-select";
import styled from "@emotion/styled";

export const StyledSelect = styled(Select)`
  background-color: #fafafa;
  border-color: var(--border-color);
  color: #4a4a4a;

  .react-dropdown-select-clear,
  .react-dropdown-select-dropdown-handle {
    color: #4a4a4a;
  }

  .react-dropdown-select-option {
    padding: 0.25rem 0.5rem;
    border-radius: 0.5rem;
    background-color: var(--accent-color);
    color: #ffffff;
    font-weight: 600;
  }

  .react-dropdown-select-input {
    color: #4a4a4a;
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

    background-color: #fafafa;
    color: #4a4a4a !important;
    border: 1px solid var(--border-color);
    box-shadow: none;
  }

  .react-dropdown-select-item {
    color: #4a4a4a;
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
