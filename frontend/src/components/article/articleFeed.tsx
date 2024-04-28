import { ReactNode } from "react";
import classes from "./articleFeed.module.css";

function ArticleFeed({ children, style }: { children: ReactNode, style?: any }) {
    return <div className={classes.articleFeed} style={style} >{children}</div>
};

export default ArticleFeed;