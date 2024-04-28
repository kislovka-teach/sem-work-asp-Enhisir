import { Link } from "react-router-dom";
import { Tag } from "../../../types";
import Container from "../../container";

import classes from "./resumeTagList.module.css";
import {ResumeTag, ResumeTagButton } from "../resumeTag/resumeTag";

function ResumeTagList({ tags }: { tags: Tag[] }) {
    return <Container>
        <div className={classes.horizontalBlock}>
            {
                tags.flatMap(tag => (<ResumeTag tag={tag}/>))
            }
            <ResumeTagButton />
            {/* <button className={classes.resumeTagAddButton} onClick={() => alert("sfdsf")}><p>добавить</p></button> */}
        </div>
    </Container>;
}

export default ResumeTagList;