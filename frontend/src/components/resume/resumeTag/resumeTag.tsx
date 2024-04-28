import { Tag } from "../../../types";

import classes from "./resumeTag.module.css";

export function ResumeTag({ tag, editable = false }: { tag: Tag, editable?: boolean }) {
    return <div className={[classes.resumeTag, (editable ? classes.resumeTagEditable: '')].join(" ").trim()}>
        <p>{tag.name}</p>
    </div>;
}

export function ResumeTagButton({ ...props }: { props?: any[] }) {
    return <button className={classes.resumeTagAddButton} {...props}>
        <p>добавить</p>
    </button>;
}

export default { ResumeTag, ResumeTagButton };