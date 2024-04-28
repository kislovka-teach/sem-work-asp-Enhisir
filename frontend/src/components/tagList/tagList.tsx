import { useState } from 'react';
import { Tag } from '../../types';

import classes from './tagList.module.css';

function TagList() {
    const [tagList, setTagList] = useState<Tag[]>([
        {
            id: 1,
            name: "sdfdsf sdfds fsdfdsfs"
        },
        {
            id: 1,
            name: "sdfdsf sdfds fsdfdsfs sdfdsf sdfds fsdfdsfs sdfdsf sdfds fsdfdsfssudo apt install tor torbrowser-launcher"
        },
        {
            id: 1,
            name: "sdfdsf sdfds fsdfdsfs"
        },
        {
            id: 1,
            name: "sdfdsf sdfds fsdfdsfs"
        }
    ]);

    return <div className={classes.tagList}>
        <h4 className={classes.tagHeader} >ТОП 10 ТЭГОВ МЕСЯЦА</h4>
        {
            tagList?.flatMap((tag, index) =>
                <div className={classes.tag} key={`tag_thumb_${index}`}>
                    <h4>{tag.name}</h4>
                </div>)
        }
    </div>;
}
export default TagList;