import { Author } from "../../types";

import classes from "./authorblock.module.css";

function AuthorBlock({ author }: { author: Author }) {
    return <div className={classes.authorBlockContainer}>
        <div className={classes.avatarContainer}><img src={author.avatarLink} /></div>
        <h4>{ author.nickname }</h4>
    </div>
};

export default AuthorBlock;