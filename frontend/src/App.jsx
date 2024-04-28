import './App.css'
import Header from './components/header';
import ArticleFeedPage from './pages/articleFeed/articleFeed'
import { Routes, Route } from 'react-router-dom';
import ArticleFullPage from './pages/articleFull/articleFull';

function App() {
    return (
        <>
            <Header />
            <main>
                <Routes>
                    <Route path="/" element={<ArticleFeedPage />}></Route>
                    <Route path="/articles/:articleId" element={<ArticleFullPage />}></Route>
                </Routes>

            </main>
        </>
    )
}

export default App
