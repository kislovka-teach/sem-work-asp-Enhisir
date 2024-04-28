import { useState } from 'react';
import { Link } from 'react-router-dom';
import { ArticleThumbnail } from '../../types';

import classes from './PopularArticlesList.module.css';

function PopularArticlesList() {
    const [popularArticlesList, setPopularArticlesList] = useState<ArticleThumbnail[]>([
        {
            id: 1,
            title: "sdfdsf sdfds fsdfdsfs"
        },
        {
            id: 2,
            title: "sdfdsf sdfds fsdfdsfs sdfdsf sdfds fsdfdsfs sdfdsf sdfds fsdfdsfssudo apt install tor torbrowser-launcher"
        },
        {
            id: 3,
            title: "sdfdsf sdfds fsdfdsfs"
        },
        {
            id: 4,
            title: "sdfdsf sdfds fsdfdsfs"
        }
    ]);

    return <div className={classes.popularArticlesList}>
        <h4 className={classes.articleHeader} >ЧИТАЮТ СЕЙЧАС</h4>
        {
            popularArticlesList?.flatMap((article, index) =>
                <div className={classes.article} key={`article_thumb_${index}`}>
                    <Link to={`/articles/${article.id}`}><h4>{article.title}</h4></Link>
                </div>)
        }
    </div>;
}
export default PopularArticlesList;