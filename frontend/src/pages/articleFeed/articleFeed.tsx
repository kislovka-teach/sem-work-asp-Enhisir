import { useEffect, useState } from "react";
import { Article } from "../../types";
import ArticleContainer from "../../components/article";
import PopularTagsList from "../../components/popularTagsList";
import PopularArticlesList from "../../components/popularArticlesList";
import CustomBeatLoader from "../../components/beatLoader";
import Container from "../../components/container";
import Feed from "../../components/general/feed";

import classes from "./articleFeed.module.css";
import api from "../../config/axios";

function ArticleFeedPage() {
    const [loading, setLoading] = useState<boolean>(true);
    const [articles, setArticles] = useState<Article[] | null>();

    useEffect(() => {
        api.get("articles")
        .then(response => {
            console.log(response.data);
            setArticles(response.data);
        })
        .catch(() => alert("error!!!"))
        .finally(() => setLoading(false));
    }, []);

    if (loading) return <CustomBeatLoader />;
    
    return <div className={classes.horizontalBlock}>
        <Feed style={{ paddingBottom: '1.5rem' }}>{
            articles && articles.length > 0 
            ? articles?.flatMap((item, index) => <ArticleContainer 
            key={`article_${index}`} article={item} isShort={true} />)
            : <Container><h2>Статьи не найдены</h2></Container>
        }</Feed>
        <div className={classes.rightSegment}>
            <PopularTagsList />
            <PopularArticlesList />
        </div>
    </div>;
}

export default ArticleFeedPage;