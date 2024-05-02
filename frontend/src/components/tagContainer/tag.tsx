import { Tag } from "../../types";

import classes from "./tag.module.css";

export function TagItem({ tag, editable = false }: { tag: Tag, editable?: boolean }) {
    return <div className={[classes.resumeTag, (editable ? classes.resumeTagEditable : '')].join(" ").trim()}>
        <p>{tag.name}</p>
    </div>;
}

export function TagButton({ ...props }: { props?: any[] }) {
    return <button className={classes.resumeTagAddButton} {...props}>
        <p>добавить</p>
    </button>;
}

export default { TagItem, TagButton };