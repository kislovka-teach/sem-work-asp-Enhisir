import { useAuth } from "../../auth";
import { Commentary } from "../../types";
import Container from "../general/container";
import CommentaryBlock from "./commentary";

import classes from "./commentaryThread.module.css";
import MakeCommentaryBlock from "./makeCommentary";

function CommentaryThread({
  articleId,
  rootCommentaries,
  isNested = false,
}: {
  articleId: number;
  rootCommentaries: Commentary[];
  isNested?: boolean;
}) {
  const { user } = useAuth();
  return !isNested ? (
    <Container className={classes.containerCustomBorder}>
      <h2>Комментарии</h2>
      {user != null && <MakeCommentaryBlock articleId={articleId} />}
      {rootCommentaries.flatMap((c: Commentary, index: number) => (
        <CommentaryBlock key={`commentary_${index}`} commentary={c} />
      ))}
    </Container>
  ) : (
    <div className={classes.commentaryThreadNested}>
      {rootCommentaries.flatMap((c: Commentary, index: number) => (
        <CommentaryBlock key={`commentary_${index}`} commentary={c} />
      ))}
    </div>
  );
}

export default CommentaryThread;
