import { useEffect, useRef, useState } from "react";
import { Profile } from "../../types";
import CustomBeatLoader from "../../components/beatLoader";
import Container from "../../components/general/container";
import { useNavigate } from "react-router-dom";
import api from "../../config/axios";
import { CustomInput } from "../../components/general";

import classes from "./editProfile.module.css";
import Config from "../../config/config";
import { ValidationParameter, validate } from "../../services/validation";
import { GetAvatar, GetImage } from "../../services/image";

function EditProfilePage() {
  const navigate = useNavigate();

  const [loading, setLoading] = useState<boolean>(true);
  const [profileInfo, setProfileInfo] = useState<Profile | null>();

  const [image, setImage] = useState({
    preview: "",
    raw: null,
  });
  const imageButtonRef = useRef();

  const [baseDataError, setBaseDataError] = useState<string>();
  const [firstname, setFirstname] = useState<string>();
  const [lastname, setLastname] = useState<string>();

  const [changePasswordError, setChangePasswordError] = useState<string>();
  const [oldPassword, setOldPassword] = useState<string>("");
  const [newPassword, setNewPassword] = useState<string>("");

  const baseDataValidationParameters: ValidationParameter[] = [
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
  ];

  const changePasswordValidationParameters: ValidationParameter[] = [
    {
      field: "oldPassword",
      predicate: (pwd: string | null) => Boolean(pwd),
      errorMessage: 'Поле "старый пароль" не заполнено',
    },
    {
      field: "newPassword",
      predicate: (pwd: string | null) => Boolean(pwd && pwd.length >= 6),
      errorMessage: 'Поле "новый пароль" не заполнено',
    },
    {
      field: "newPassword",
      predicate: (pwd: string | null) => Boolean(pwd && pwd.length >= 6),
      errorMessage: "Пароль не может быть меньше 6 символов",
    },
  ];

  useEffect(() => {
    api
      .get(`profile`)
      .then((response) => {
        const newProfile = response.data;
        console.log(response.data);
        setProfileInfo(newProfile);
        setImage({
          preview: GetAvatar(newProfile.avatarLink),
          raw: "",
        });
        setFirstname(newProfile.firstName);
        setLastname(newProfile.lastName);
      })
      .catch(() => setProfileInfo(null))
      .finally(() => setLoading(false));
  }, []);

  const updateImage = () => {
    if (image.raw == null) return;

    const form = new FormData();
    form.append("image", image.raw);
    api
      .postForm("profile/update_image", form)
      .then(() => navigate(0))
      .catch(() => alert("!!!"));
  };

  const editBaseData = () => {
    const data = {
      firstname: firstname,
      lastname: lastname,
    };

    const problems = validate(baseDataValidationParameters, data);
    if (problems.length > 0) {
      setBaseDataError(problems[0].errorMessage);
      return;
    }

    api
      .patch("profile/edit", data)
      .then(() => navigate(0))
      .catch(() => alert("!!!"));
  };

  const changePassword = () => {
    const data = {
      oldPassword: oldPassword,
      newPassword: newPassword,
    };

    const problems = validate(changePasswordValidationParameters, data);
    if (problems.length > 0) {
      setChangePasswordError(problems[0].errorMessage);
      return;
    }

    api
      .post("profile/change_password", data)
      .then(() => navigate(0))
      .catch(() => alert("!!!"));
  };

  if (loading) return <CustomBeatLoader />;

  if (profileInfo == null)
    return (
      <Container>
        <h2>Нет доступа</h2>
      </Container>
    );

  return (
    <div className={classes.sizedContainer}>
      <Container>
        <h2>Профиль</h2>

        <div className={classes.horizontalGroup}>
          <div className={classes.avatarContainer}>
            <img src={image.preview} />
          </div>
          <div className={classes.avatarButtonGroup}>
            <input
              ref={imageButtonRef}
              name="image"
              type="file"
              id="upload-button"
              style={{ display: "none" }}
              onChange={(e) => {
                if (e.target.files == null) return;
                setImage({
                  preview: URL.createObjectURL(e.target.files[0]),
                  raw: e.target.files[0],
                });
              }}
            />
            <button
              className="alternative"
              onClick={() => imageButtonRef.current.click()}
            >
              Обновить фото
            </button>
            <button onClick={updateImage}>Сохранить</button>
          </div>
        </div>

        <div className={classes.verticalGroup}>
          <h3>Данные</h3>
          {baseDataError != null && baseDataError != "" && (
            <span className={classes.error}>{baseDataError}</span>
          )}
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
          <button onClick={editBaseData}>Сохранить</button>
        </div>

        <div className={classes.verticalGroup}>
          <h3>Смена пароля</h3>
          {changePasswordError != null && changePasswordError != "" && (
            <span className={classes.error}>{changePasswordError}</span>
          )}
          <CustomInput
            type="password"
            placeholder="старый пароль"
            value={oldPassword}
            onChange={(e: any) => setOldPassword(e.target.value)}
          />
          <CustomInput
            type="password"
            placeholder="новый пароль"
            value={newPassword}
            onChange={(e: any) => setNewPassword(e.target.value)}
          />
          <button onClick={changePassword}>Сохранить</button>
        </div>
      </Container>
    </div>
  );
}

export default EditProfilePage;
