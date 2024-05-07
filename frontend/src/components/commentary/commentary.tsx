import Markdown from "react-markdown";
import { Commentary, Role } from "../../types";
import AuthorBlock from "../authorBlock";

import classes from "./commentary.module.css";
import CommentaryThread from "./commentaryThread";
import { useAuth } from "../../auth";
import { useState } from "react";
import MakeCommentaryBlock from "./makeCommentary";

function CommentaryBlock({ commentary }: { commentary: Commentary }) {
  const { user } = useAuth();

  const isAdmin = user?.Role == Role.Admin;

  const [enableAnswer, setEnableAnswer] = useState<boolean>(false);

  return (
    <>
      <div
        style={{
          width: "100%",
          display: "flex",
          flexDirection: "column",
          gap: "0.5rem",
        }}
      >
        <div className={classes.commentaryContainer}>
          <div className={classes.commentary}>
            <AuthorBlock author={commentary.author}></AuthorBlock>
            <Markdown>{commentary.text}</Markdown>
          </div>
          <div className={classes.commentaryButtons}>
            <button
              className="alternative small"
              onClick={() => setEnableAnswer(true)}
            >
              ответить
            </button>
            {isAdmin && <button className="alternative small">скрыть</button>}
          </div>
        </div>
        {enableAnswer && (
          <MakeCommentaryBlock
            articleId={commentary.articleId}
            parentId={commentary.id}
            onCancel={() => setEnableAnswer(false)}
          />
        )}
        {commentary.children && commentary.children.length > 0 && (
          <CommentaryThread
            rootCommentaries={commentary.children}
            isNested={true}
          />
        )}
      </div>
    </>
  );
}

export default CommentaryBlock;
