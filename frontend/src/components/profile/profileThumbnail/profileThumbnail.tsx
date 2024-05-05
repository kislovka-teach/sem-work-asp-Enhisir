import { useNavigate } from "react-router-dom";
import { Profile, getProfileName } from "../../../types";
import Container from "../../general/container";
import classes from "./profileThumbnail.module.css";
import Config from "../../../config/config";

function ProfileThumbnail({ profile }: { profile: Profile }) {
  const navigate = useNavigate();

  return (
    <Container>
      <div className={classes.horizontalBlock}>
        <div className={classes.avatarContainer}>
          <img src={profile.avatarLink ?? Config.DefaultImage} />
        </div>
        <div className={classes.verticalBlock}>
          <h2>{profile.userName}</h2>
          <p className={classes.name}>{getProfileName(profile)}</p>
        </div>
        <div className={[classes.verticalBlock, classes.buttonBlock].join(" ")}>
          <button>подписаться</button>
          {profile.hasResume && (
            <button
              className="alternative"
              onClick={() => navigate(`/resumes/${profile.userName}`)}
            >
              перейти в резюме
            </button>
          )}
        </div>
      </div>
    </Container>
  );
}

export default ProfileThumbnail;
