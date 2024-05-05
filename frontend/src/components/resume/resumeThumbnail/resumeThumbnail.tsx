import { Link } from "react-router-dom";
import {
  GradeToString,
  ResumeThumbnailType,
  getProfileName,
} from "../../../types";
import Container from "../../general/container";

import classes from "./resumeThumbnail.module.css";
import { GetAvatar } from "../../../services/image";

function ResumeThumbnail({
  thumb,
  enableLink = false,
}: {
  thumb: ResumeThumbnailType;
  enableLink?: boolean;
}) {
  return (
    <Container>
      <div className={classes.horizontalBlock}>
        <div className={classes.avatarContainer}>
          <img src={GetAvatar(thumb.avatarLink)} />
        </div>
        <div className={classes.verticalBlock} style={{ justifyContent: "center"}}>
          {enableLink ? (
            <Link className="altHref" to={`/resumes/${thumb.userName}`}>
              <h2>{getProfileName(thumb)}</h2>
            </Link>
          ) : (
            <h2>{getProfileName(thumb)}</h2>
          )}
          <p className={classes.profession}>{thumb.profession}</p>
          <div className={classes.resumeFooter}>
            {thumb.lookingForWork ? (
              <div className={classes.salary}>
                <p>
                  {`${getBeautifulNumber(thumb.leftSalaryBorder)} - 
                            ${getBeautifulNumber(thumb.rightSalaryBorder)} ₽`}
                </p>
              </div>
            ) : (
              <div className={classes.dontLookFroWork}>
                <p>Не ищу работу</p>
              </div>
            )}
            <h2>{GradeToString[thumb.grade]}</h2>
          </div>
        </div>
      </div>
    </Container>
  );
}

function getBeautifulNumber(number: number) {
  return number.toString().replace(/(\d)(?=(\d\d\d)+([^\d]|$))/g, "$1 ");
}

export default ResumeThumbnail;
