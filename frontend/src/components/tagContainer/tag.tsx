import { Tag } from "../../types";

import classes from "./tag.module.css";

export function TagItem({
  tag,
  classname,
  onClick,
  editable = false,
}: {
  tag: Tag;
  editable?: boolean;
  onClick?: () => void;
  classname?: string;
}) {
  return (
    <div
      className={[
        classes.tag,
        editable ? classes.tagEditable : "",
        classname ?? "",
      ]
        .join(" ")
        .trim()}
    >
      <p onClick={onClick}>{tag.name}</p>
    </div>
  );
}

export function TagButton({ ...props }: { props?: any[] }) {
  return (
    <button className={classes.tagAddButton} {...props}>
      <p>добавить</p>
    </button>
  );
}

export default { TagItem, TagButton };
