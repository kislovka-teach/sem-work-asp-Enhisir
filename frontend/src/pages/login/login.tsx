import { useEffect, useState } from "react";
import classes from "./login.module.css";
import { CustomInput } from "../../components/general";
import Container from "../../components/general/container";
import api from "../../config/axios";
import { useAuth } from "../../auth";
import { useNavigate } from "react-router-dom";
import { validate, ValidationParameter } from "../../services/validation";

function LoginPage() {
  const navigate = useNavigate();
  const { setUserLoading, storeAuthInfo } = useAuth();

  const [username, setUsername] = useState<string>("");
  const [password, setPassword] = useState<string>("");

  const [error, setError] = useState<string>("");

  const validationParameters: ValidationParameter[] = [
    {
      field: "username",
      predicate: (username: string | null) => Boolean(username),
      errorMessage: 'Поле "логин" не заполнено',
    },
    {
      field: "password",
      predicate: (password: string | null) => Boolean(password),
      errorMessage: 'Поле "пароль" не заполнено',
    },
    {
      field: "password",
      predicate: (password: string | null) =>
        Boolean(password && password.length >= 6),
      errorMessage: 'Поле "пароль" заполнено неверно',
    },
  ];

  const loginAction = (e: any) => {
    const problems = validate(validationParameters, {
      username: username,
      password: password,
    });
    if (problems.length > 0) {
      setError(problems[0].errorMessage);
      return;
    }

    api
      .post("auth/login", {
        userName: username,
        password: password,
      })
      .then((response: any) => {
        setUserLoading(false);
        storeAuthInfo(response.data);
        navigate("/");
      })
      .catch((state) => {
        console.log(state.response.status);
        if (state.response.status >= 500) {
          setError("ошибка на сервере");
        } else if (state.response.status == 401) {
          setError("неверный логин или пароль");
        } else {
          setError("неизвестная ошибка");
        }
      });
  };

  return (
    <div className={classes.loginSizedContainer}>
      <Container>
        <h2 style={{ textAlign: "center", paddingBottom: "1.5rem" }}>
          Вход в аккаунт
        </h2>
        {error != null && error != "" && (
          <span className={classes.error}>{error}</span>
        )}
        <CustomInput
          placeholder="логин"
          value={username}
          onChange={(e: any) => setUsername(e.target.value)}
        />
        <CustomInput
          type="password"
          placeholder="пароль"
          value={password}
          onChange={(e: any) => setPassword(e.target.value)}
        />
        <button onClick={loginAction}>войти</button>
      </Container>
    </div>
  );
}

export default LoginPage;
