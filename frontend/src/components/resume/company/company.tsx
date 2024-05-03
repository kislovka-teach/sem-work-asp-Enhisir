import { GradeToString, WorkPlace } from "../../../types";

import classes from "./company.module.css";

function Company({ companyInfo, enableUpperBorder = false }: { companyInfo: WorkPlace, enableUpperBorder?: boolean }) {
    const monthNames = [
        "Январь", "Февраль", "Март",
        "Апрель", "Май", "Июнь",
        "Июль", "Август", "Сентябрь",
        "Октябрь", "Ноябрь", "Декабрь"
    ];

    const dateBegin = new Date(companyInfo.dateBegin);
    const dateEnd = companyInfo.dateEnd ? new Date(companyInfo.dateEnd) : null;

    return <div className={[classes.companyBlock, enableUpperBorder ? classes.borderTop : ''].join(" ").trim()}>
        <div className={classes.dates}>
            <p>{monthNames[dateBegin.getMonth() - 1]} {dateBegin.getFullYear()} -</p>
            <p>
                {
                    dateEnd
                        ? `${monthNames[dateEnd!.getMonth()]} ${dateEnd!.getFullYear()}`
                        : "Настоящее время"
                }
            </p>
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