import { ReactNode } from "react";
import classes from "./feed.module.css";

function Feed({ children, style }: { children: ReactNode, style?: any }) {
    return <div className={classes.feed} style={style} >{children}</div>
};

export default Feed;