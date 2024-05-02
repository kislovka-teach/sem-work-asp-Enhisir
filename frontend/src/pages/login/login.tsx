import { useState } from 'react';
import classes from './login.module.css'
import { CustomInput } from '../../components/general';
import Container from '../../components/container';

function Login() {
    const [username, setUsername] = useState<string>("");
    const [password, setPassword] = useState<string>("");

    const [error, setError] = useState<string>("");

    return <div className={classes.loginSizedContainer}>
        <Container>
            <h2 style={{ textAlign: "center", paddingBottom:"1.5rem" }}>Вход в аккаунт</h2>
            { error != null && error != "" && <span className={classes.error}>{error}</span> }
            <CustomInput placeholder="логин" 
            value={username} onChange={(e: any) => setUsername(e.target.value)} />
            <CustomInput placeholder="пароль" 
            value={password} onChange={(e: any) => setPassword(e.target.value)} />
            <button>войти</button>
        </Container>
    </div>
}

export default Login;