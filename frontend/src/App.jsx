import './App.css'
import Header from './components/general/header';
import ArticleFeedPage from './pages/articleFeed/articleFeed'
import { Routes, Route } from 'react-router-dom';
import ArticleFullPage from './pages/articleFull/articleFull';
import ProfilePage from './pages/profile/profile'
import ResumeProfilePage from './pages/resumeProfile';
import Login from './pages/login/login'
import Registration from './pages/registration/registration'

function App() {
    return (
        <>
            <Header />
            <main>
                <Routes>
                    <Route path="/" element={<ArticleFeedPage />}></Route>
                    <Route path="/articles" element={<ArticleFeedPage />}></Route>
                    <Route path="/articles/:articleId" element={<ArticleFullPage />}></Route>
                    <Route path="/users/:username" element={<ProfilePage />}></Route>
                    <Route path="/resumes/:profileId" element={<ResumeProfilePage />}></Route>
                    <Route path="/login" element={<Login />}></Route>
                    <Route path="/registration" element={<Registration />}></Route>
                </Routes>

            </main>
        </>
    )
}

export default App
