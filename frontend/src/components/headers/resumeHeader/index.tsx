import { Link } from "react-router-dom";
import SearchComponent from "../../general/search/search";

import Logo from '../../../assets/logo.svg'
import classes from "./header.module.css"
import { TopicNames } from "../../../types";

function ResumeHeader() {
    return <header className={classes.header}>
        <div className={classes.leftWrapper} >
            <Link to="/" className={classes.logoContainer}>
                <div className={classes.logoImage}>
                    <img src={Logo}></img>
                </div>
                <h1 className={classes.logoTitle}>Брах</h1>
            </Link>
            {
                Object.entries(TopicNames).flatMap(([key, name]: [string, string]) => (
                    <Link key={`topic_${key}`}
                        to={`/articles?topic=${key}`} className={classes.headerItem}>{name}</Link>))
            }
            <Link to="/resumes" className={classes.headerItem}>Резюме</Link>
        </div>
        <div className={classes.midWrapper}>
            <SearchComponent baseSearchString="/resumes" />
        </div>
        <div className={classes.rightWrapper} >
            <Link to="/login" className={classes.profileContainer}>
                Войти
            </Link>
        </div>
    </header>
}

export default ResumeHeader;