import Markdown from "react-markdown";
import Container from "../container";
import { Article } from "../../types";
import Authorblock from "../authorBlock";
import KarmaBlock from "../karma";
import { Link } from "react-router-dom";

function ArticleCatalogContainer({ article }: { article: Article }) {
    return <Container>
        <Authorblock author={article.author} />
        <h2>{article.title}</h2>
        <Markdown>{article.text}</Markdown>
        <div style={{ width: '100%', display: 'flex', flexDirection: 'row', justifyContent: 'space-between' }}>
            <KarmaBlock points={article.karma} onDown={() => { }} onUp={() => { }} />
            <Link to={`/articles/${article.id}`}>Подробнее</Link>
        </div>
    </Container>
};

export default ArticleCatalogContainer;