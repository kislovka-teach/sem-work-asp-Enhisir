import { useEffect, useState } from 'react';
import classes from './login.module.css'
import { CustomInput } from '../../components/general';
import Container from '../../components/general/container';
import api from '../../config/axios';
import { useAuth } from '../../auth';
import { useNavigate } from 'react-router-dom';

function Login() {
    const navigate = useNavigate();
    const { setUserLoading, storeAuthInfo } = useAuth();

    const [username, setUsername] = useState<string>("");
    const [password, setPassword] = useState<string>("");

    const [error, setError] = useState<string>("");

    const loginAction = (e: any) => {
        // e.preventDafault();

        api.post("auth/login", {
            userName: username,
            password: password 
        }).then((response: any) => {
            setUserLoading(false);
            storeAuthInfo(response.data);
            navigate("/");
        })
        .catch((state) => {
            console.log(state.response.status);
            if (state.response.status >= 500) {
                setError("ошибка на сервере");
            }
            else if (state.response.status == 401) {
                setError("неверный логин или пароль");
            }
            else {
                setError("неизвестная ошибка");
            }
    });
    }

    return <div className={classes.loginSizedContainer}>
        <Container>
            <h2 style={{ textAlign: "center", paddingBottom:"1.5rem" }}>Вход в аккаунт</h2>
            { error != null && error != "" && <span className={classes.error}>{error}</span> }
            <CustomInput required placeholder="логин" 
            value={username} onChange={(e: any) => setUsername(e.target.value)} />
            <CustomInput required placeholder="пароль" 
            value={password} onChange={(e: any) => setPassword(e.target.value)} />
            <button onClick={loginAction}>войти</button>
        </Container>
    </div>
}

export default Login;