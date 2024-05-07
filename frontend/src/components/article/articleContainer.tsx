import Markdown from "react-markdown";
import Container from "../general/container";
import { Article } from "../../types";
import AuthorBlock from "../authorBlock";
import KarmaBlock from "../karma";
import { Link } from "react-router-dom";
import { TagItem } from "../tagContainer/tag";
import TopicSpan from "./topicSpan/topicSpan";

function ArticleContainer({
  article,
  isShort = false,
}: {
  article: Article;
  isShort?: boolean;
}) {
  return (
    <Container>
      <AuthorBlock author={article.author} />
      {isShort ? (
        <Link to={`/articles/${article.id}`} className="altHref">
          <h2>{article.title}</h2>
        </Link>
      ) : (
        <h2>{article.title}</h2>
      )}
      {
        <div style={{ display: "flex", flexWrap: "wrap", flexDirection: "row", gap: "0.5rem" }}>
          <TopicSpan topic={article.topic} />
          {article.tags.flatMap((tag, index) => (
            <TagItem key={`tag_item_${index}`} tag={tag} />
          ))}
        </div>
      }
      <Markdown>{article.text}</Markdown>
      <KarmaBlock points={article.karma} onDown={() => {}} onUp={() => {}} />
    </Container>
  );
}

export default ArticleContainer;
