import { useEffect, useState } from "react";
import { Article } from "../../types";
import { ArticleCatalogContainer, ArticleFeed } from "../../components/article";

import classes from "./articleFeed.module.css";
import TagList from "../../components/tagList";
import PopularArticlesList from "../../components/popularArticlesList";

function ArticleFeedPage() {
    const [loading, setLoading] = useState<boolean | undefined>();
    const [articles, setArticles] = useState<Article[] | null>();

    useEffect(() => {
        setArticles([
            {
                author: {
                    avatarLink: 'https://sun9-79.userapi.com/impg/yqlWcDEY_zY_G76v_qtDQNxmT4xelEj7PD4eVQ/UNb379wiAtM.jpg?size=1920x1080&quality=96&sign=6fef3a6e0f180bf645c4596c8d8ae2dd&type=album',
                    nickname: "Продажная шваль 47"
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
            },
            {
                author: {
                    avatarLink: 'https://sun9-79.userapi.com/impg/yqlWcDEY_zY_G76v_qtDQNxmT4xelEj7PD4eVQ/UNb379wiAtM.jpg?size=1920x1080&quality=96&sign=6fef3a6e0f180bf645c4596c8d8ae2dd&type=album',
                    nickname: "Продажная шваль 47"
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
            },
            {
                author: {
                    avatarLink: 'https://sun9-79.userapi.com/impg/yqlWcDEY_zY_G76v_qtDQNxmT4xelEj7PD4eVQ/UNb379wiAtM.jpg?size=1920x1080&quality=96&sign=6fef3a6e0f180bf645c4596c8d8ae2dd&type=album',
                    nickname: "Продажная шваль 47"
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
            },
            {
                author: {
                    avatarLink: 'https://sun9-79.userapi.com/impg/yqlWcDEY_zY_G76v_qtDQNxmT4xelEj7PD4eVQ/UNb379wiAtM.jpg?size=1920x1080&quality=96&sign=6fef3a6e0f180bf645c4596c8d8ae2dd&type=album',
                    nickname: "Продажная шваль 47"
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
            },
            {
                author: {
                    avatarLink: 'https://sun9-79.userapi.com/impg/yqlWcDEY_zY_G76v_qtDQNxmT4xelEj7PD4eVQ/UNb379wiAtM.jpg?size=1920x1080&quality=96&sign=6fef3a6e0f180bf645c4596c8d8ae2dd&type=album',
                    nickname: "Продажная шваль 47"
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
        ]);
    }, []);

    return <div className={classes.horizontalBlock}>
        <ArticleFeed>{
            articles?.flatMap(item => <ArticleCatalogContainer article={item} />)
        }</ArticleFeed>
        <div className={classes.rightSegment}>
            <TagList />
            <PopularArticlesList />
        </div>
    </div>;

    return;
}

export default ArticleFeedPage;