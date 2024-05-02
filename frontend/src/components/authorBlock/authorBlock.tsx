import { Link } from "react-router-dom";
import { Author } from "../../types";

import classes from "./authorblock.module.css";

function AuthorBlock({ author }: { author: Author }) {
    return <div className={classes.authorBlockContainer}>
        <div className={classes.avatarContainer}><img src={author.avatarLink} /></div>
        <Link className="altHref" to={"/users/" + author.nickname}><h4>{ author.nickname }</h4></Link>
    </div>
};

export default AuthorBlock;