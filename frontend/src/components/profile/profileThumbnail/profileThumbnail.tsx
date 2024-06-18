import { useActionData, useNavigate } from "react-router-dom";
import { Profile, getProfileName } from "../../../types";
import { GetAvatar } from "../../../services/image";
import Container from "../../general/container";
import classes from "./profileThumbnail.module.css";
import { useAuth } from "../../../auth";
import api from "../../../config/axios";

function ProfileThumbnail({
  profile
}: {
  profile: Profile;
  isMe?: boolean;
}) {
  const navigate = useNavigate();
  const { user } = useAuth();

  const isMe = profile.userName == user?.userName;

  const subscribe = () => {
    api
      .post(`/users/${profile.userName}/subscribe`)
      .then(() => navigate(0));
  }

  const unsubscribe = () => {
    api
      .delete(`/users/${profile.userName}/unsubscribe`)
      .then(() => navigate(0));
  }

  return (
    <Container>
      <div className={classes.horizontalBlock}>
        <div className={classes.avatarContainer}>
          <img src={GetAvatar(profile.avatarLink)} />
        </div>
        <div className={classes.verticalBlock}>
          <h2>{profile.userName}</h2>
          <p className={classes.name}>{getProfileName(profile)}</p>
        </div>
        <div className={[classes.verticalBlock, classes.buttonBlock].join(" ")}>
          { !isMe && (
            profile.subscribed 
            ? <button onClick={unsubscribe}>отписаться</button>
            : <button onClick={subscribe}>подписаться</button>
          )}
          {profile.hasResume ? (
            <button
              className="alternative"
              onClick={() =>
                navigate(`/resumes/${isMe ? "me" : profile.userName}`)
              }
            >
              перейти в резюме
            </button>
          ) : (
            isMe && (
              <button
                className="alternative"
                onClick={() => navigate(`/resumes/new`)}
              >
                создать резюме
              </button>
            )
          )}
          {isMe && (
            <button
              className="alternative"
              onClick={() => navigate(`/profile/edit`)}
            >
              редактировать профиль
            </button>
          )}
        </div>
      </div>
    </Container>
  );
}

export default ProfileThumbnail;
