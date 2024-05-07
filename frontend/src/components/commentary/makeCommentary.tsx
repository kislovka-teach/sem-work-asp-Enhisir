import classes from "./commentary.module.css";
import Commentary from "../../types";
import { useState } from "react";
import { CustomTextArea } from "../general";
import api from "../../config/axios";
import { useNavigate } from "react-router-dom";

export default function MakeCommentaryBlock({
  articleId,
  parentId = undefined,
  onCancel = null,
}: {
  articleId: number;
  parentId?: number;
  onCancel?: () => void;
}) {
  const navigate = useNavigate();

  const [text, setText] = useState<string>("");

  const saveCommentary = () => {
    api
      .post("commentaries/new", {
        articleId: articleId,
        parentId: parentId ?? null,
        text: text,
      } as Commentary)
      .then(() => navigate(0));
  };

  return (
    <div className={classes.commentaryContainer}>
      <div className={classes.commentary}>
        <CustomTextArea
          style={{ width: "100%", minHeight: "5rem" }}
          value={text}
          onChange={(e) => setText(e.target.value)}
        />
        <div
          style={{
            width: "100%",
            display: "flex",
            flexDirection: "row",
            gap: "0.5rem",
          }}
        >
          <button
            className={text.length > 0 ? null : "alternative"}
            onClick={saveCommentary}
          >
            ответить
          </button>
          {onCancel != null && (
            <button className="alternative" onClick={onCancel}>
              отмена
            </button>
          )}
        </div>
      </div>
    </div>
  );
}
