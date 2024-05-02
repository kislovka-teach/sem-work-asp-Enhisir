import { useEffect, useState } from "react";
import { Grade, ResumeProfile } from "../../types";
import Feed from "../../components/general/feed";
import ResumeHeader from "../../components/resume/resumeHeader";
import TagContainer from "../../components/tagContainer";
import CompanyList from "../../components/resume/company/companyList";
import CustomBeatLoader from "../../components/beatLoader";
import Container from "../../components/container";

import classes from "./resumeProfile.module.css";

function ResumeProfilePage() {
    const [loading, setLoading] = useState<boolean>();
    const [resumeInfo, setResumeInfo] = useState<ResumeProfile | null>();

    useEffect(() => {
        setLoading(true);
        setResumeInfo({
            header: {
                avatarLink: 'https://sun9-79.userapi.com/impg/yqlWcDEY_zY_G76v_qtDQNxmT4xelEj7PD4eVQ/UNb379wiAtM.jpg?size=1920x1080&quality=96&sign=6fef3a6e0f180bf645c4596c8d8ae2dd&type=album',
                firstName: "Konstantin",
                lastName: "Rerich",
                profession: "raspizdyai",
                lookingForWork: true,
                leftSalaryBorder: 100_000,
                rightSalaryBorder: 150_000,
                grade: Grade.Senior
            },
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
            workPlaces: [
                {
                    companyName: "Dsfsdfsf",
                    profession: "developer",
                    grade: Grade.Intern,
                    description: "dsfsdfsfdsfsdfsfdsfsdfsfdsfsdfsfdsfsdfsfdsfsdfsfdsfsdfsfdsfsdfsfdsfsdfsfdsfsdfsfdsfsdfsfdsfsdfsfdsfsdfsfdsfsdfsfdsfsdfsfdsfsdfsfdsfsdfsfdsfsdfsf",
                    dateBegin: new Date("2024-08-04"),
                    dateEnd: new Date("2024-08-04"),
                },
                {
                    companyName: "Dsfsdfsf",
                    profession: "developer",
                    grade: Grade.Intern,
                    description: "dsfsdfsfdsfsdfsfdsfsdfsfdsfsdfsfdsfsdfsfdsfsdfsfdsfsdfsfdsfsdfsfdsfsdfsfdsfsdfsfdsfsdfsfdsfsdfsfdsfsdfsfdsfsdfsfdsfsdfsfdsfsdfsfdsfsdfsfdsfsdfsf",
                    dateBegin: new Date("2024-08-04"),
                    dateEnd: new Date("2024-08-04"),
                },
                {
                    companyName: "dsfsdfsf",
                    profession: "developer",
                    grade: Grade.Intern,
                    description: "dsfsdfsfdsfsdfsfdsfsdfsfdsfsdfsfdsfsdfsfdsfsdfsfdsfsdfsfdsfsdfsfdsfsdfsfdsfsdfsfdsfsdfsfdsfsdfsfdsfsdfsfdsfsdfsfdsfsdfsfdsfsdfsfdsfsdfsfdsfsdfsf",
                    dateBegin: new Date("2024-08-04"),
                    dateEnd: new Date("2024-08-04"),
                },
            ],
            about: "dsfsdfsfdsfsdfsfdsfsdfsfdsfsdfsfdsfsdf dsfsdfsfdsfsdfsfdsfsdfsfdsfsdfsfdsfsdf dsfsdfsfdsfsdfsfdsfsdfsfdsfsdfsfdsfsdf dsfsdfsfdsfsdfsfdsfsdfsfdsfsdfsfdsfsdf",
        });
        setLoading(false);
    }, []);

    if (loading) return <CustomBeatLoader />;

    if (resumeInfo == null) return <Container><h2>Резюме не найдено</h2></Container>;

    return <Feed style={{ paddingBottom: "1.5rem" }}>
        <ResumeHeader thumb={resumeInfo.header} />
        <TagContainer tags={resumeInfo.tags} />
        <CompanyList companies={resumeInfo.workPlaces} />
        <Container>
            <h2 className={classes.aboutHeader}>Обо мне</h2>
            <p>{resumeInfo.about}</p>
        </Container>
    </Feed>;
}

export default ResumeProfilePage;