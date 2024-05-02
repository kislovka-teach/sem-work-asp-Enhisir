import { useEffect, useState } from "react";
import { Gender, Profile } from "../../types";
import CustomBeatLoader from "../../components/beatLoader";
import Feed from "../../components/general/feed";
import Container from "../../components/container";
import ProfileHeader from "../../components/profile/profileHeader/profileHeader";

import classes from "./profile.module.css";
import TagContainer from "../../components/tagContainer";
import ArticleContainer from "../../components/article";

function ProfilePage({ }) {
    const [loading, setLoading] = useState<boolean>();
    const [profileInfo, setProfileInfo] = useState<Profile | null>();

    useEffect(() => {
        setLoading(true);
        setProfileInfo({
            firstName: "Kostya",
            lastName: 'Rerich',
            avatarLink: 'https://sun9-79.userapi.com/impg/yqlWcDEY_zY_G76v_qtDQNxmT4xelEj7PD4eVQ/UNb379wiAtM.jpg?size=1920x1080&quality=96&sign=6fef3a6e0f180bf645c4596c8d8ae2dd&type=album',
            username: "enhisir@yandex.ru",
            tags: [
                {
                    id: 1,
                    name: 'sdsdsd'
                },
                {
                    id: 2,
                    name: 'sdsdsd fasdsd'
                }
            ],
            articles: [
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
                },
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
                },
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
                },
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
                },
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
            ],
        });
        setLoading(false);
    }, []);

    if (loading) return <CustomBeatLoader />;

    if (profileInfo == null) return <Container><h2>Профиль не найден</h2></Container>;


    return <Feed style={{ paddingBottom: "1.5rem" }}>
        <ProfileHeader profile={profileInfo} />
        <TagContainer tags={profileInfo.tags} />
        {
            profileInfo.articles && profileInfo.articles.length > 0
                ? profileInfo.articles?.flatMap((item, index) =>
                    <ArticleContainer key={`article_container_${index}`} article={item} isShort={true} />)
                : <Container><h2>Статьи не найдены</h2></Container>
        }
    </Feed>;
};

export default ProfilePage;