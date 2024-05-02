import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { Article, Commentary } from "../../types";
import ArticleContainer from "../../components/article";
import PopularTagsList from "../../components/popularTagsList";
import PopularArticlesList from "../../components/popularArticlesList";
import CustomBeatLoader from "../../components/beatLoader";
import CommentaryThread from "../../components/commentary/commentaryThread";
import Container from "../../components/container";
import Feed from "../../components/general/feed";

import classes from "./articleFull.module.css";
import api from "../../config/axios";


function ArticleFullPage() {
    const { articleId } = useParams();
    
    const [articleLoading, setArticleLoading] = useState<boolean | undefined>();
    const [article, setArticle] = useState<Article | null>(null);
    const [rootCommentariesLoading, setRootCommentariesLoading] = useState<boolean | undefined>();
    const [rootCommentaries, setRootCommentaries] = useState<Commentary[] | null>(null);

    useEffect(() => {
        setArticleLoading(true);
        api.get("articles/" + articleId)
        .then(response => {
            console.log(response.data);
            setArticle(response.data);
        })
        .catch(() => alert("error!!!"))
        .finally(() => setArticleLoading(false));
        setArticleLoading(false);
    }, []);

    useEffect(() => {
        setRootCommentariesLoading(true);
        setRootCommentaries([
            {
                id: 1,
                author: {
                    avatarLink: 'https://sun9-79.userapi.com/impg/yqlWcDEY_zY_G76v_qtDQNxmT4xelEj7PD4eVQ/UNb379wiAtM.jpg?size=1920x1080&quality=96&sign=6fef3a6e0f180bf645c4596c8d8ae2dd&type=album',
                    userName: "Продажная шваль 47"
                },
                text: 'Почему я люблю хонкай стар рейл',
                children: [
                    {
                        id: 10,
                        author: {
                            avatarLink: 'https://sun9-79.userapi.com/impg/yqlWcDEY_zY_G76v_qtDQNxmT4xelEj7PD4eVQ/UNb379wiAtM.jpg?size=1920x1080&quality=96&sign=6fef3a6e0f180bf645c4596c8d8ae2dd&type=album',
                            userName: "Продажная шваль 47"
                        },
                        text: 'Почему я люблю хонкай стар рейл',
                        children: [],
                        datetime: new Date(),
                    },
                ],
                datetime: new Date()
            },
            {
                id: 2,
                author: {
                    avatarLink: 'https://sun9-79.userapi.com/impg/yqlWcDEY_zY_G76v_qtDQNxmT4xelEj7PD4eVQ/UNb379wiAtM.jpg?size=1920x1080&quality=96&sign=6fef3a6e0f180bf645c4596c8d8ae2dd&type=album',
                    userName: "Продажная шваль 47"
                },
                text: 'Почему я люблю хонкай стар рейл',
                datetime: new Date()
            },
            {
                id: 3,
                author: {
                    avatarLink: 'https://sun9-79.userapi.com/impg/yqlWcDEY_zY_G76v_qtDQNxmT4xelEj7PD4eVQ/UNb379wiAtM.jpg?size=1920x1080&quality=96&sign=6fef3a6e0f180bf645c4596c8d8ae2dd&type=album',
                    userName: "Продажная шваль 47"
                },
                text: 'Почему я люблю хонкай стар рейл',
                datetime: new Date()
            }
        ]);
        setRootCommentariesLoading(false);
    }, []);

    if (articleLoading) return <CustomBeatLoader />;

    if (article == null) return <Container><h2>Статья не найдена</h2></Container>;

    return <div className={classes.horizontalBlock}>
        <Feed>
            <ArticleContainer article={article} />
            {
                rootCommentariesLoading
                    ? <CustomBeatLoader />
                    : <CommentaryThread rootCommentaries={rootCommentaries ?? []} />
            }
        </Feed>
        <div className={classes.rightSegment}>
            <PopularTagsList />
            <PopularArticlesList />
        </div>
    </div>;
}

export default ArticleFullPage;