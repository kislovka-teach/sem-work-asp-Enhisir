import { GradeToString, ResumeThumbnail } from "../../../types";
import Container from "../../container";

import classes from "./resumeHeader.module.css"

function ResumeHeader({ thumb }: { thumb: ResumeThumbnail }) {
    return <Container>
        <div className={classes.horizontalBlock}>
            <div className={classes.avatarContainer}>
                <img src={thumb.avatarLink} />
            </div>
            <div className={classes.verticalBlock}>
                <h1>{thumb.name}</h1>
                <p className={classes.profession}>{thumb.profession}</p>
                <div className={classes.resumeFooter}>
                    <div className={classes.salary}>
                        <p>{getBeautifulNumber(thumb.leftSalaryBorder)} - {getBeautifulNumber(thumb.rightSalaryBorder)} ₽</p>
                    </div>
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