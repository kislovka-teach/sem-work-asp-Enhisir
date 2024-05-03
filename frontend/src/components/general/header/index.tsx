import { Link } from "react-router-dom";
import SearchComponent from "../search/search";

import Logo from '../../../assets/logo.svg'
import classes from "./header.module.css"

function Header() {
    return <header className={classes.header}>
        <div className={classes.leftWrapper} >
            <Link to="/" className={classes.logoContainer}>
                <div className={classes.logoImage}>
                    <img src={Logo}></img>
                </div>
                <h1 className={classes.logoTitle}>Брах</h1>
            </Link>
        </div>
        <div className={classes.midWrapper}>
            <SearchComponent />
        </div>
        <div className={classes.rightWrapper} >
            <Link to="/login" className={classes.profileContainer}>
                Войти
            </Link>
        </div>
    </header>
}

export default Header;