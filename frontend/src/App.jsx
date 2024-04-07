import { Navigate, Route, Routes } from 'react-router-dom'
import './App.css'
import Header from './components/header';
import Container from './components/container';
import { ArticleCatalogContainer, ArticleFeed } from './components/article';

function App() {

    const a = {
        author: {
            avatarLink: 'https://sun9-79.userapi.com/impg/yqlWcDEY_zY_G76v_qtDQNxmT4xelEj7PD4eVQ/UNb379wiAtM.jpg?size=1920x1080&quality=96&sign=6fef3a6e0f180bf645c4596c8d8ae2dd&type=album',
            nickname: "Продажная шваль 47"
        },
        title: 'Почему я люблю хонкай стар рейл',
        text: 'Это все реклама и рофл, я не люблю хонкай стар рейл Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut faucibus pulvinar elementum integer enim neque volutpat ac tincidunt. Turpis in eu mi bibendum neque egestas. Facilisis gravida neque convallis a. Id nibh tortor id aliquet. Sodales neque sodales ut etiam sit amet nisl purus. Tincidunt arcu non sodales neque sodales ut etiam. Dui nunc mattis enim ut tellus elementum sagittis vitae. Ornare lectus sit amet est placerat in egestas. Amet porttitor eget dolor morbi non arcu risus quis varius. Sed adipiscing diam donec adipiscing tristique. Et ultrices neque ornare aenean euismod elementum nisi quis. Id faucibus nisl tincidunt eget. Accumsan in nisl nisi scelerisque. Bibendum ut tristique et egestas quis ipsum suspendisse ultrices. Id volutpat lacus laoreet non curabitur gravida arcu ac. Curabitur gravida arcu ac tortor dignissim convallis aenean et tortor. Auctor augue mauris augue neque gravida. Placerat vestibulum lectus mauris ultrices eros in cursus turpis. Ridiculus mus mauris vitae ultricies leo integer...',
        karma: 15,
    };

    return (
        <>
            <Header />
            <main>
                <ArticleFeed>
                    <Container>
                        <h3>Burn the Witch</h3>
                    </Container>
                    <ArticleCatalogContainer article={a} />
                </ArticleFeed>
                {/* <Routes>
          <Route path='*' element={Navigate("/")} />
        </Routes> */}
            </main>
        </>
    )
}

export default App
