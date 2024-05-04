import { useEffect, useState } from "react";
import { useSearchParams } from "react-router-dom";

import { ResumeThumbnail } from "../../types";
import PopularTagsList from "../../components/popularTagsList";
import PopularArticlesList from "../../components/popularArticlesList";
import CustomBeatLoader from "../../components/beatLoader";
import Container from "../../components/general/container";
import Feed from "../../components/general/feed";
import ResumeHeader from "../../components/resume/resumeHeader";
import ResumeFilter from "../../components/resume/resumeFilter/resumeFilter";

import classes from "./resumeFeed.module.css";
import api from "../../config/axios";

function ResumeFeedPage() {
    // const [searchParams,] = useSearchParams();
    const [loading, setLoading] = useState<boolean>(true);
    const [resumes, setResumes] = useState<ResumeThumbnail[] | null>();

    // useEffect(() => {
    //     console.log(searchParams.get("tags"))
    //     api.get("resumes", { params: searchParams })
    //         .then(response => {
    //             console.log(response.data);
    //             setArticles(response.data);
    //         })
    //         .catch(() => {
    //             alert("error!!!");
    //             setArticles([]);
    //         })
    //         .finally(() => setLoading(false));
    // }, [searchParams]);

    useEffect(() => {
        api.get("resumes")
            .then(response => {
                console.log(response.data);
                setResumes(response.data);
            })
            .catch(() => console.log("error while making a response"))
            .finally(() => setLoading(false));
    }, []);

    if (loading) return <CustomBeatLoader />;

    return <div className={classes.horizontalBlock}>
        <Feed style={{ paddingBottom: '1.5rem', width: "40vw" }}>
            {
                resumes && resumes.length > 0
                    ? resumes?.flatMap((item, index) => <ResumeHeader
                        key={`article_${index}`} thumb={item} enableLink={true} />)
                    : <Container><h2>Резюме не найдены</h2></Container>
            }
        </Feed>
        <div className={classes.rightSegment}>
            <ResumeFilter />
            <PopularTagsList />
            <PopularArticlesList />
        </div>
    </div>;
}

export default ResumeFeedPage;