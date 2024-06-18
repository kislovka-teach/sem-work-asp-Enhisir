import { useEffect, useState } from "react";
import { ResumeProfile } from "../../types";
import Feed from "../../components/general/feed";
import ResumeThumbnail from "../../components/resume/resumeThumbnail";
import TagContainer from "../../components/tagContainer";
import CompanyList from "../../components/resume/company/companyList";
import CustomBeatLoader from "../../components/beatLoader";
import Container from "../../components/general/container";

import classes from "./resumeProfile.module.css";
import api from "../../config/axios";
import { Link, useParams } from "react-router-dom";
import { useAuth } from "../../auth";

function ResumeProfilePage() {
  const { username } = useParams();

  const [loading, setLoading] = useState<boolean>(true);
  const [resumeInfo, setResumeInfo] = useState<ResumeProfile | null>();

  const { user } = useAuth();
  const isMe = user != null && user.userName == resumeInfo?.userName;

  useEffect(() => {
    api
      .get(`resumes/${username}`)
      .then((response) => {
        console.log(response.data);
        setResumeInfo(response.data);
      })
      .catch(() => setResumeInfo(null))
      .finally(() => setLoading(false));
  }, [username]);

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
      <ResumeThumbnail thumb={resumeInfo} />
      {resumeInfo.tags != null && resumeInfo.tags.length > 0 && (
        <TagContainer tags={resumeInfo.tags} />
      )}
      {resumeInfo.workPlaces != null && resumeInfo.workPlaces.length > 0 && (
        <CompanyList companies={resumeInfo.workPlaces} />
      )}
      <Container>
        {(resumeInfo.telegram != null || resumeInfo.email != null) && (
          <>
            <div className={classes.verticalBlock}>
              <h2 className={classes.aboutHeader}>Связаться</h2>
              {resumeInfo.telegram != null && (
                <p>
                  <span style={{ fontWeight: "600" }}>telegram:</span>{" "}
                  <Link to={resumeInfo.telegram}>{resumeInfo.telegram}</Link>
                </p>
              )}
              {resumeInfo.email != null && (
                <p>
                  <span style={{ fontWeight: "600" }}>почта:</span>{" "}
                  {resumeInfo.email}
                </p>
              )}
            </div>
          </>
        )}
        <div className={classes.verticalBlock}>
          <h2 className={classes.aboutHeader}>Обо мне</h2>
          <p>{resumeInfo.about}</p>
        </div>
      </Container>
    </Feed>
  );
}

export default ResumeProfilePage;
