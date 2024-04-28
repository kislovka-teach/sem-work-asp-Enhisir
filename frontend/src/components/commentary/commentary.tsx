import Markdown from "react-markdown";
import { Commentary } from "../../types";
import AuthorBlock from "../authorBlock";

import classes from './commentary.module.css'
import CommentaryThread from "./commentaryThread";

function CommentaryBlock({ commentary }: { commentary: Commentary }) {
    return <>
        <div className={classes.commentary}>
            <div className={classes.commentaryHeader}>
                <AuthorBlock author={commentary.author}></AuthorBlock>
                <button className="alternative">скрыть</button>
            </div>
            <Markdown>{commentary.text}</Markdown>
        </div>
        {
            commentary.children && <CommentaryThread rootCommentaries={commentary.children} isNested={true} />
        }
    </>
}

export default CommentaryBlock;