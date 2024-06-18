import { useEffect, useState } from "react";
import classes from "./register.module.css";
import { CustomInput } from "../../components/general";
import Container from "../../components/general/container";
import api from "../../config/axios";
import { useAuth } from "../../auth";
import { useNavigate } from "react-router-dom";
import { ValidationParameter, validate } from "../../services/validation";

function RegisterPage() {
  const navigate = useNavigate();
  const { setUserLoading, storeAuthInfo } = useAuth();

  const [username, setUsername] = useState<string>("");
  const [firstname, setFirstname] = useState<string>("");
  const [lastname, setLastname] = useState<string>("");
  const [password, setPassword] = useState<string>("");
  const [repeatPassword, setRepeatPassword] = useState<string>("");

  const [error, setError] = useState<string>("");

  const validationParameters: ValidationParameter[] = [
    {
      field: "username",
      predicate: (username: string | null) => Boolean(username),
      errorMessage: 'Поле "логин" не заполнено',
    },
    {
      field: "firstname",
      predicate: (firstname: string | null) => Boolean(firstname),
      errorMessage: 'Поле "имя" не заполнено',
    },
    {
      field: "lastname",
      predicate: (lastname: string | null) => Boolean(lastname),
      errorMessage: 'Поле "фамилия" не заполнено',
    },
    {
      field: "password",
      predicate: (pwd: string | null) => Boolean(pwd),
      errorMessage: 'Поле "пароль" не заполнено',
    },
    {
      field: "password",
      predicate: (pwd: string | null) => Boolean(pwd && pwd.length >= 6),
      errorMessage: "Пароль не может быть меньше 6 символов",
    },
    {
      field: "repeatPassword",
      predicate: (repeatPwd: string | null) => Boolean(repeatPwd),
      errorMessage: 'Поля "повторите пароль" не заполнено',
    },
    {
      field: "repeatPassword",
      predicate: (repeatPwd: string | null) => repeatPwd == password,
      errorMessage: "Пароли должны совпадать",
    },
  ];

  const loginAction = (e: any) => {
    const problems = validate(validationParameters, {
      username: username,
      firstname: firstname,
      lastname: lastname,
      password: password,
      repeatPassword: repeatPassword,
    });
    if (problems.length > 0) {
      setError(problems[0].errorMessage);
      return;
    }

    api
      .post("auth/register", {
        username: username,
        firstname: firstname,
        lastname: lastname,
        password: password,
        repeatPassword: repeatPassword,
      })
      .then((response: any) => {
        setUserLoading(false);
        storeAuthInfo(response.data);
        navigate("/");
      })
      .catch((state) => {
        const response = state.response;
        console.log(state);
        if (response.status >= 500) {
          setError("ошибка на сервере");
        } else if (response.data.errors) {
          setError(Object.entries(response.data.errors)[0][1] as string);
        } else {
          setError("неизвестная ошибка");
        }
      });
  };

  return (
    <div className={classes.registerSizedContainer}>
      <Container>
        <h2 style={{ textAlign: "center", paddingBottom: "1.5rem" }}>
          Регистрация
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
          placeholder="имя"
          value={firstname}
          onChange={(e: any) => setFirstname(e.target.value)}
        />
        <CustomInput
          placeholder="фамилия"
          value={lastname}
          onChange={(e: any) => setLastname(e.target.value)}
        />
        <CustomInput
          type="password"
          placeholder="пароль"
          value={password}
          onChange={(e: any) => setPassword(e.target.value)}
        />
        <CustomInput
          type="password"
          placeholder="повторите пароль"
          value={repeatPassword}
          onChange={(e: any) => setRepeatPassword(e.target.value)}
        />
        <button onClick={loginAction}>зарегистрироваться</button>
      </Container>
    </div>
  );
}

export default RegisterPage;
