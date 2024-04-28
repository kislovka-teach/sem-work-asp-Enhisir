import Markdown from "react-markdown";
import Container from "../container";
import { Article } from "../../types";
import AuthorBlock from "../authorBlock";
import KarmaBlock from "../karma";
import { Link } from "react-router-dom";

function ArticleContainer({ article, isShort = false }: { article: Article, isShort?: boolean }) {
    return <Container>
        <AuthorBlock author={article.author} />
        {
            isShort
                ? <Link to={`/articles/${article.id}`} className="altHref">
                    <h2>{article.title}</h2>
                </Link>
                : <h2>{article.title}</h2>
        }
        <Markdown>{article.text}</Markdown>
        <KarmaBlock points={article.karma} onDown={() => { }} onUp={() => { }} />
    </Container>
};

export default ArticleContainer;