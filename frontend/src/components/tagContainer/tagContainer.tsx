import { Tag } from "../../types";
import Container from "../general/container";
import { TagItem, TagButton } from "./tag";
import classes from "./tagContainer.module.css";

function TagContainer({ tags, editable = false }: { tags: Tag[], editable?: boolean }) {
    return <Container>
        <div className={classes.horizontalBlock}>
            {
                tags.flatMap((tag, index) => (<TagItem key={`tag_item_${index}`} tag={tag} editable={editable}/>))
            }
            { editable && <TagButton /> }
        </div>
    </Container>;
}

export default TagContainer;