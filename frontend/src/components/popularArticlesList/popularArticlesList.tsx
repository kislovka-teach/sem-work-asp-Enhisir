import { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import { ArticleThumbnail } from "../../types";
import CustomBeatLoader from "../beatLoader";

import classes from "./PopularArticlesList.module.css";
import api from "../../config/axios";

function PopularArticlesList() {
  const [loading, setLoading] = useState<boolean>(true);
  const [popularArticlesList, setPopularArticlesList] = useState<
    ArticleThumbnail[]
  >([
    {
      id: 1,
      title: "sdfdsf sdfds fsdfdsfs",
    },
    {
      id: 2,
      title:
        "sdfdsf sdfds fsdfdsfs sdfdsf sdfds fsdfdsfs sdfdsf sdfds fsdfdsfssudo apt install tor torbrowser-launcher",
    },
    {
      id: 3,
      title: "sdfdsf sdfds fsdfdsfs",
    },
    {
      id: 4,
      title: "sdfdsf sdfds fsdfdsfs",
    },
  ]);

  useEffect(() => {
    api.get("articles/top").then((response) => {
      setPopularArticlesList(response.data);
      setLoading(false);
    });
  }, []);

  return (
    <div className={classes.popularArticlesList}>
      <h4 className={classes.articleHeader}>ЧИТАЮТ СЕЙЧАС</h4>
      {loading ? (
        <CustomBeatLoader />
      ) : (
        popularArticlesList?.flatMap((article, index) => (
          <div className={classes.article} key={`article_thumb_${index}`}>
            <Link to={`/articles/${article.id}`}>
              <h4>{article.title}</h4>
            </Link>
          </div>
        ))
      )}
    </div>
  );
}
export default PopularArticlesList;
