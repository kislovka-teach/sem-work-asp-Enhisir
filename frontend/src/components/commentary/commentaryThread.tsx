import { Commentary } from "../../types";
import Container from "../container";
import CommentaryBlock from "./commentary";

import classes from "./commentaryThread.module.css"

function CommentaryThread({ rootCommentaries, isNested = false }: { rootCommentaries: Commentary[], isNested?: boolean }) {
    return (!isNested)
        ? <Container className={classes.containerCustomBorder}>
            <h2>Комментарии</h2>
            {
                rootCommentaries.flatMap((c: Commentary, index: number) =>
                    <CommentaryBlock key={`commentary_${index}`} commentary={c} />)
            }
        </Container>
        : <div className={classes.commentaryThreadNested}>
            {
                rootCommentaries.flatMap((c: Commentary, index: number) =>
                    <CommentaryBlock key={`commentary_${index}`} commentary={c} />)
            }
        </div>;
}

export default CommentaryThread;