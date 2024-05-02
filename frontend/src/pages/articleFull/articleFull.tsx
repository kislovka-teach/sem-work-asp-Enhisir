import { useEffect, useState } from "react";
import { Article, Commentary } from "../../types";
import ArticleContainer from "../../components/article";
import PopularTagsList from "../../components/popularTagsList";
import PopularArticlesList from "../../components/popularArticlesList";
import CustomBeatLoader from "../../components/beatLoader";
import CommentaryThread from "../../components/commentary/commentaryThread";
import Container from "../../components/container";
import Feed from "../../components/general/feed";

import classes from "./articleFull.module.css";

function ArticleFullPage() {
    const [articleLoading, setArticleLoading] = useState<boolean | undefined>();
    const [article, setArticle] = useState<Article | null>(null);
    const [rootCommentariesLoading, setRootCommentariesLoading] = useState<boolean | undefined>();
    const [rootCommentaries, setRootCommentaries] = useState<Commentary[] | null>(null);

    useEffect(() => {
        setArticleLoading(true);
        setArticle(
            {
                author: {
                    avatarLink: 'https://sun9-79.userapi.com/impg/yqlWcDEY_zY_G76v_qtDQNxmT4xelEj7PD4eVQ/UNb379wiAtM.jpg?size=1920x1080&quality=96&sign=6fef3a6e0f180bf645c4596c8d8ae2dd&type=album',
                    username: "Продажная шваль 47"
                },
                title: 'Почему я люблю хонкай стар рейл',
                text: "`sql  INSERT INTO illness_history (id, illness_id, clinic_card_id, doctor_id, start_date, end_date, additional_info)\n" +
                    "VALUES\n(31, 1, 1, 1, current_date, current_date + interval '5 days', ''),\n(32, 2, 2, 2, current_date, current_date + interval '5 days', ''),\n" +
                    "(33, 3, 3, 3, current_date, current_date + interval '5 days', ''),\n(34, 4, 4, 4, current_date, current_date + interval '5 days', ''),\n" +
                    "(528, 3, 28, 8, current_date, current_date + interval '5 days', ''),\n(529, 4, 29, 9, current_date, current_date + interval '5 days', ''),\n(530, 5, 30, 10, current_date, current_date + interval '5 days', '');`",
                karma: 15,
                id: 0,
                thread: {
                    id: 0,
                    name: ""
                },
                tags: []
            }
        );
        setArticleLoading(false);
    }, []);

    useEffect(() => {
        setRootCommentariesLoading(true);
        setRootCommentaries([
            {
                id: 1,
                author: {
                    avatarLink: 'https://sun9-79.userapi.com/impg/yqlWcDEY_zY_G76v_qtDQNxmT4xelEj7PD4eVQ/UNb379wiAtM.jpg?size=1920x1080&quality=96&sign=6fef3a6e0f180bf645c4596c8d8ae2dd&type=album',
                    username: "Продажная шваль 47"
                },
                text: 'Почему я люблю хонкай стар рейл',
                children: [
                    {
                        id: 10,
                        author: {
                            avatarLink: 'https://sun9-79.userapi.com/impg/yqlWcDEY_zY_G76v_qtDQNxmT4xelEj7PD4eVQ/UNb379wiAtM.jpg?size=1920x1080&quality=96&sign=6fef3a6e0f180bf645c4596c8d8ae2dd&type=album',
                            username: "Продажная шваль 47"
                        },
                        text: 'Почему я люблю хонкай стар рейл',
                        children: [],
                        datetime: undefined
                    },
                ]
            },
            {
                id: 2,
                author: {
                    avatarLink: 'https://sun9-79.userapi.com/impg/yqlWcDEY_zY_G76v_qtDQNxmT4xelEj7PD4eVQ/UNb379wiAtM.jpg?size=1920x1080&quality=96&sign=6fef3a6e0f180bf645c4596c8d8ae2dd&type=album',
                    username: "Продажная шваль 47"
                },
                text: 'Почему я люблю хонкай стар рейл',
                datetime: undefined
            },
            {
                id: 3,
                author: {
                    avatarLink: 'https://sun9-79.userapi.com/impg/yqlWcDEY_zY_G76v_qtDQNxmT4xelEj7PD4eVQ/UNb379wiAtM.jpg?size=1920x1080&quality=96&sign=6fef3a6e0f180bf645c4596c8d8ae2dd&type=album',
                    username: "Продажная шваль 47"
                },
                text: 'Почему я люблю хонкай стар рейл',
                datetime: undefined
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