import classes from "./articleFeed.module.css";

function ArticleFeed({ children }: { children: React.ReactNode }) {
    return <div className={classes.articleFeed}>{children}</div>
};

export default ArticleFeed;