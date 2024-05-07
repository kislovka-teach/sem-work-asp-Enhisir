import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { Article } from "../../types";
import { ArticleContainer } from "../../components/article";
import PopularArticlesList from "../../components/popularArticlesList";
import CustomBeatLoader from "../../components/beatLoader";
import CommentaryThread from "../../components/commentary/commentaryThread";
import Container from "../../components/general/container";
import Feed from "../../components/general/feed";

import classes from "./articleFull.module.css";
import api from "../../config/axios";

function ArticleFullPage() {
  const { articleId } = useParams();

  const [articleLoading, setArticleLoading] = useState<boolean>(true);
  const [article, setArticle] = useState<Article | null>(null);

  useEffect(() => {
    api
      .get("articles/" + articleId)
      .then((response) => {
        console.log(response.data);
        setArticle(response.data);
      })
      .catch(() => alert("error!!!"))
      .finally(() => setArticleLoading(false));
  }, [articleId]);

  if (articleLoading) return <CustomBeatLoader />;

  if (article == null)
    return (
      <Container>
        <h2>Статья не найдена</h2>
      </Container>
    );

  return (
    <div className={classes.horizontalBlock}>
      <Feed style={{ width: "40vw" }}>
        <ArticleContainer article={article} />
        <CommentaryThread
          rootCommentaries={article.commentaries}
          articleId={article.id}
        />
      </Feed>
      <div className={classes.rightSegment}>
        <PopularArticlesList />
      </div>
    </div>
  );
}

export default ArticleFullPage;
