import Markdown from "react-markdown";
import Container from "../container";
import { Article } from "../../types";
import Authorblock from "./authorBlock";

function ArticleCatalogContainer({ article }: { article: Article }) {
    return <Container>
        <Authorblock author={article.author} />
        <h2>{article.title}</h2>
        <Markdown>{article.text}</Markdown>
    </Container>
};

export default ArticleCatalogContainer;