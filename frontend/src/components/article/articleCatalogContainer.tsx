import Markdown from "react-markdown";
import Container from "../container";
import { Article } from "../../types";
import Authorblock from "./authorBlock";
import KarmaBlock from "../karma";

function ArticleCatalogContainer({ article }: { article: Article }) {
    return <Container>
        <Authorblock author={article.author} />
        <h2>{article.title}</h2>
        <Markdown>{article.text}</Markdown>
        <KarmaBlock points={article.karma} onDown={() => { }} onUp={() => { }} />
    </Container>
};

export default ArticleCatalogContainer;