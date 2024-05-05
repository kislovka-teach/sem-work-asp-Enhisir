import { useNavigate } from "react-router-dom";
import { Profile, getProfileName } from "../../../types";
import { GetAvatar } from "../../../services/image";
import Container from "../../general/container";
import classes from "./profileThumbnail.module.css";

function ProfileThumbnail({ profile, isMe = false }: { profile: Profile, isMe?: boolean }) {
  const navigate = useNavigate();

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
          {
            !isMe && <button>подписаться</button>
          }
          {
            profile.hasResume
              ? (
                <button
                  className="alternative"
                  onClick={() => navigate(`/resumes/${profile.userName}`)}
                >
                  перейти в резюме
                </button>
              )
              : isMe && (
                <button
                  className="alternative"
                  onClick={() => navigate(`/resumes/${profile.userName}`)}
                >
                  создать резюме
                </button>
              )
            }
          {
            isMe
            && (
              <button
                className="alternative"
                onClick={() => navigate(`/profile/edit`)}>
                редактировать профиль
              </button>
            )
          }
        </div>
      </div>
    </Container>
  );
}

export default ProfileThumbnail;
