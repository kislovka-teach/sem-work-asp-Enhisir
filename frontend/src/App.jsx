import { Routes, Route } from "react-router-dom";

import MainHeader from "./components/headers/mainHeader";

import ArticleFeedPage from "./pages/articleFeed/articleFeed";
import ArticleFullPage from "./pages/articleFull/articleFull";
import ProfilePage from "./pages/profile/profile";

import LoginPage from "./pages/login/login";
import RegisterPage from "./pages/register/register";

import ResumeHeader from "./components/headers/resumeHeader";
import ResumeFeedPage from "./pages/resumeFeed/resumeFeed";
import ResumeProfilePage from "./pages/resumeProfile";

import "./App.css";
import MyProfilePage from "./pages/myProfile/myProfile";

function App() {
  return (
    <Routes>
      <Route
        path="/resumes/*"
        element={
          <>
            <ResumeHeader />
            <main>
              <Routes>
                <Route path="/" element={<ResumeFeedPage />} />
                <Route path="/:username" element={<ResumeProfilePage />} />
              </Routes>
            </main>
          </>
        }
      />
      <Route
        path="/"
        element={
          <>
            <MainHeader />
            <main>
              <ArticleFeedPage />
            </main>
          </>
        }
      ></Route>
      <Route
        path="/*"
        element={
          <>
            <MainHeader />
            <main>
              <Routes>
                <Route path="/articles" element={<ArticleFeedPage />} />
                <Route
                  path="/articles/:articleId"
                  element={<ArticleFullPage />}
                />
                <Route path="/users/me" element={<MyProfilePage />} />
                <Route path="/users/:username" element={<ProfilePage />} />
                <Route path="/login" element={<LoginPage />} />
                <Route path="/register" element={<RegisterPage />} />
              </Routes>
            </main>
          </>
        }
      />
    </Routes>
  );
}

export default App;
