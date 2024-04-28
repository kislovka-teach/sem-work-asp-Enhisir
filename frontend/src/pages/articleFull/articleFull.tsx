import { useEffect, useState } from "react";
import { Article, Commentary, Grade, ResumeThumbnail } from "../../types";
import { ArticleContainer, ArticleFeed } from "../../components/article";

import classes from "./articleFull.module.css";
import TagList from "../../components/tagList";
import PopularArticlesList from "../../components/popularArticlesList";
import CustomBeatLoader from "../../components/beatLoader";
import CommentaryThread from "../../components/commentary/commentaryThread";
import Container from "../../components/container";
import ResumeHeader from "../../components/resume/resumeHeader";
import ResumeTagList from "../../components/resume/resumeTagList/resumeTagList";

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
                    nickname: "Продажная шваль 47"
                },
                text: 'Почему я люблю хонкай стар рейл',
                children: [
                    {
                        id: 10,
                        author: {
                            avatarLink: 'https://sun9-79.userapi.com/impg/yqlWcDEY_zY_G76v_qtDQNxmT4xelEj7PD4eVQ/UNb379wiAtM.jpg?size=1920x1080&quality=96&sign=6fef3a6e0f180bf645c4596c8d8ae2dd&type=album',
                            nickname: "Продажная шваль 47"
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
                    nickname: "Продажная шваль 47"
                },
                text: 'Почему я люблю хонкай стар рейл',
                datetime: undefined
            },
            {
                id: 3,
                author: {
                    avatarLink: 'https://sun9-79.userapi.com/impg/yqlWcDEY_zY_G76v_qtDQNxmT4xelEj7PD4eVQ/UNb379wiAtM.jpg?size=1920x1080&quality=96&sign=6fef3a6e0f180bf645c4596c8d8ae2dd&type=album',
                    nickname: "Продажная шваль 47"
                },
                text: 'Почему я люблю хонкай стар рейл',
                datetime: undefined
            }
        ]);
        setRootCommentariesLoading(false);
    }, []);

    const thumb: ResumeThumbnail = {
        avatarLink: 'https://sun9-79.userapi.com/impg/yqlWcDEY_zY_G76v_qtDQNxmT4xelEj7PD4eVQ/UNb379wiAtM.jpg?size=1920x1080&quality=96&sign=6fef3a6e0f180bf645c4596c8d8ae2dd&type=album',
        name: "Konstantin Rerich",
        profession: "raspizdyai",
        lookingForWork: true,
        leftSalaryBorder: 100_000,
        rightSalaryBorder: 150_000,
        grade: Grade.Senior
    };

    if (articleLoading) return <CustomBeatLoader />;

    if (article == null) return <Container><h2>Статья не найдена</h2></Container>;

        return <div className={classes.horizontalBlock}>
            <ArticleFeed>
                <ResumeHeader thumb={thumb} />
                <ResumeTagList tags={[
                    {
                        id: 1,
                        name: 'sdsdsd'
                    },
                    {
                        id: 2,
                        name: 'sdsdsd fasdsd'
                    }
                ]} />
                <ArticleContainer article={article} />
                {
                    rootCommentariesLoading 
                    ? <CustomBeatLoader />
                    : <CommentaryThread rootCommentaries={rootCommentaries ?? []} />
                }
            </ArticleFeed>
            <div className={classes.rightSegment}>
                <TagList />
                <PopularArticlesList />
            </div>
        </div>;
}

export default ArticleFullPage;