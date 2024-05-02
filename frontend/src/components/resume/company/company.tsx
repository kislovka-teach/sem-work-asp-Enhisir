import { GradeToString, WorkPlace } from "../../../types";

import classes from "./company.module.css";

function Company({ companyInfo, enableUpperBorder = false }: { companyInfo: WorkPlace, enableUpperBorder?: boolean }) {
    return <div className={[classes.companyBlock, enableUpperBorder ? classes.borderTop : ''].join(" ").trim()}>
        <div className={classes.dates}>
            <p>{companyInfo.dateBegin.toLocaleString('ru-ru', { month: 'long', year: 'numeric' })} -</p>
            <p>{companyInfo.dateEnd.toLocaleString('ru-ru', { month: 'long', year: 'numeric' })}</p>
        </div>
        <div className={classes.baseTextBlock}>
            <h2>{companyInfo.companyName}</h2>
            <p className={classes.profession}>
                {companyInfo.profession} ({GradeToString[companyInfo.grade]})
            </p>
            <p className={classes.description}>{companyInfo.description}</p>
        </div>
    </div>
}

export default Company;