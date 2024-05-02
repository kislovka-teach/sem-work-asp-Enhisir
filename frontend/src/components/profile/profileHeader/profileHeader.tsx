
import { Profile, getProfileName } from "../../../types";
import Container from "../../container";
import classes from "./profileHeader.module.css"

function ProfileHeader({ profile }: { profile: Profile }) {

    return <Container>
        <div className={classes.horizontalBlock}>
            <div className={classes.avatarContainer}>
                <img src={profile.avatarLink} />
            </div>
            <div className={classes.verticalBlock}>
                <h2>{profile.username}</h2>
                <p className={classes.name}>{getProfileName(profile)}</p>
            </div>
            <div className={[classes.verticalBlock, classes.buttonBlock].join(" ")}>
                <button>подписаться</button>
                <button className="alternative">перейти в резюме</button>
            </div>
        </div>
    </Container>;
}

export default ProfileHeader;