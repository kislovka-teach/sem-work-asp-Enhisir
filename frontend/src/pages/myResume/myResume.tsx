import { useEffect, useState } from "react";
import { ResumeProfile } from "../../types";
import Feed from "../../components/general/feed";
import ResumeThumbnail from "../../components/resume/resumeThumbnail";
import TagContainer from "../../components/tagContainer";
import CompanyList from "../../components/resume/company/companyList";
import CustomBeatLoader from "../../components/beatLoader";
import Container from "../../components/general/container";

import classes from "./myResume.module.css";
import api from "../../config/axios";
import { useNavigate } from "react-router-dom";
import { useAuth } from "../../auth";

function MyResumePage() {
  const navigate = useNavigate();
  const { userLoading, user } = useAuth();

  const [loading, setLoading] = useState<boolean>(true);
  const [resumeInfo, setResumeInfo] = useState<ResumeProfile | null>();

  useEffect(() => {
    if (userLoading) return;

    if (user == null) navigate("/login");

    api
      .get(`resumes/${user.userName}`)
      .then((response) => {
        console.log(response.data);
        setResumeInfo(response.data);
      })
      .catch(() => setResumeInfo(null))
      .finally(() => setLoading(false));
  }, [userLoading, user]);

  if (loading) return <CustomBeatLoader />;

  if (resumeInfo == null)
    return (
      <Container style={{ width: "100%" }}>
        <h2>Резюме не найдено</h2>
      </Container>
    );

  return (
    <Feed
      style={{
        paddingBottom: "1.5rem",
        width: "40vw",
        minWidth: "min-content",
      }}
    >
      <ResumeThumbnail thumb={resumeInfo} isMe={true} />
      {resumeInfo.tags != null && resumeInfo.tags.length > 0 && (
        <TagContainer tags={resumeInfo.tags} />
      )}
      {resumeInfo.workPlaces != null && resumeInfo.workPlaces.length > 0 && (
        <CompanyList companies={resumeInfo.workPlaces} />
      )}
      <Container>
        <h2 className={classes.aboutHeader}>Обо мне</h2>
        <p>{resumeInfo.about}</p>
      </Container>
    </Feed>
  );
}

export default MyResumePage;
