import classes from "./header.module.css"

function Header() {
    return <header className={classes.header}>
        <div className={classes.leftWrapper} ></div>
        <div className={classes.rightWrapper} ></div>
    </header>
}

export default Header;