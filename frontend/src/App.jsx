import './App.css'
import Header from './components/header';
import ArticleFeedPage from './pages/articleFeed/articleFeed'
import { Routes, Route } from 'react-router-dom';
import CommentaryThread from './components/commentary/commentaryThread';

function App() {
    return (
        <>
            <Header />
            <main>
                <Routes>
                    <Route path="feed" element={<ArticleFeedPage />}></Route>
                    <Route path="/" element={
                        <CommentaryThread rootCommentaries={[
                            {
                                id: 1,
                                author: {
                                    avatarLink: 'https://sun9-79.userapi.com/impg/yqlWcDEY_zY_G76v_qtDQNxmT4xelEj7PD4eVQ/UNb379wiAtM.jpg?size=1920x1080&quality=96&sign=6fef3a6e0f180bf645c4596c8d8ae2dd&type=album',
                                    nickname: "Продажная шваль 47"
                                },
                                text: 'Почему я люблю хонкай стар рейл',
                                children: [
                                    {
                                        id: 10,
                                        author: {
                                            avatarLink: 'https://sun9-79.userapi.com/impg/yqlWcDEY_zY_G76v_qtDQNxmT4xelEj7PD4eVQ/UNb379wiAtM.jpg?size=1920x1080&quality=96&sign=6fef3a6e0f180bf645c4596c8d8ae2dd&type=album',
                                            nickname: "Продажная шваль 47"
                                        },
                                        text: 'Почему я люблю хонкай стар рейл',
                                        children: []
                                    },
                                ]
                            },
                            {
                                id: 2,
                                author: {
                                    avatarLink: 'https://sun9-79.userapi.com/impg/yqlWcDEY_zY_G76v_qtDQNxmT4xelEj7PD4eVQ/UNb379wiAtM.jpg?size=1920x1080&quality=96&sign=6fef3a6e0f180bf645c4596c8d8ae2dd&type=album',
                                    nickname: "Продажная шваль 47"
                                },
                                text: 'Почему я люблю хонкай стар рейл',
                            },
                            {
                                id: 3,
                                author: {
                                    avatarLink: 'https://sun9-79.userapi.com/impg/yqlWcDEY_zY_G76v_qtDQNxmT4xelEj7PD4eVQ/UNb379wiAtM.jpg?size=1920x1080&quality=96&sign=6fef3a6e0f180bf645c4596c8d8ae2dd&type=album',
                                    nickname: "Продажная шваль 47"
                                },
                                text: 'Почему я люблю хонкай стар рейл',
                            }
                        ]} />
                    }></Route>
                </Routes>

            </main>
        </>
    )
}

export default App
