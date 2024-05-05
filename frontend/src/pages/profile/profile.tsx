import { useEffect, useState } from "react";
import { Profile } from "../../types";
import CustomBeatLoader from "../../components/beatLoader";
import Feed from "../../components/general/feed";
import Container from "../../components/general/container";
import ProfileThumbnail from "../../components/profile/profileThumbnail/profileThumbnail";

import { ArticleContainer } from "../../components/article";
import { useParams } from "react-router-dom";
import api from "../../config/axios";

function ProfilePage({}) {
  const { username } = useParams();
  const [loading, setLoading] = useState<boolean>(true);
  const [profileInfo, setProfileInfo] = useState<Profile | null>();

  useEffect(() => {
    api
      .get(`users/${username}`)
      .then((response) => {
        console.log(response.data);
        setProfileInfo(response.data);
      })
      .catch(() => alert("user not loaded!!!"))
      .finally(() => setLoading(false));
  }, []);

  if (loading) return <CustomBeatLoader />;

  if (profileInfo == null)
    return (
      <Container>
        <h2>Профиль не найден</h2>
      </Container>
    );

  return (
    <Feed style={{ paddingBottom: "1.5rem", width: "40vw", minWidth: "min-content" }}>
      <ProfileThumbnail profile={profileInfo} />
      {profileInfo.articles && profileInfo.articles.length > 0 ? (
        profileInfo.articles?.flatMap((item, index) => (
          <ArticleContainer
            key={`article_container_${index}`}
            article={item}
            isShort={true}
          />
        ))
      ) : (
        <Container>
          <h2>Статьи не найдены</h2>
        </Container>
      )}
    </Feed>
  );
}

export default ProfilePage;
