import { Link } from "react-router-dom";
import { GradeToString, ResumeThumbnail, getProfileName } from "../../../types";
import Container from "../../general/container";

import classes from "./resumeHeader.module.css"

function ResumeHeader({ thumb, enableLink = false }:
    { thumb: ResumeThumbnail, enableLink?: boolean }) {
    return <Container>
        <div className={classes.horizontalBlock}>
            <div className={classes.avatarContainer}>
                <img src={thumb.avatarLink} />
            </div>
            <div className={classes.verticalBlock}>
                {
                    enableLink
                        ? <Link className="altHref" to={`/resumes/${thumb.userName}`}>
                            <h1>{getProfileName(thumb)}</h1>
                        </Link>
                        : <h1>{getProfileName(thumb)}</h1>
                }
                <p className={classes.profession}>{thumb.profession}</p>
                <div className={classes.resumeFooter}>
                    {
                        thumb.lookingForWork
                            ? <div className={classes.salary}>
                                <p>
                                    {`${getBeautifulNumber(thumb.leftSalaryBorder)} - 
                            ${getBeautifulNumber(thumb.rightSalaryBorder)} ₽`}
                                </p>
                            </div>
                            : <div className={classes.dontLookFroWork}><p>Не ищу работу</p></div>
                    }
                    <h2>{GradeToString[thumb.grade]}</h2>
                </div>
            </div>
        </div >
    </Container>;
}

function getBeautifulNumber(number: number) {
    return number.toString().replace(/(\d)(?=(\d\d\d)+([^\d]|$))/g, '$1 ');
}

export default ResumeHeader;