import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { GradeToString, OptionContainer, ResumeProfile } from "../../types";
import Container from "../../components/general/container";
import { CustomInput, CustomTextArea } from "../../components/general";

import classes from "./newResume.module.css";
import { Checkbox } from "@mui/material";
import { StyledSelect } from "../../components/general/styledSelect";
import Feed from "../../components/general/feed";
import api from "../../config/axios";
import { useAuth } from "../../auth";

export default function NewResumePage() {
  const navigate = useNavigate();

  const { user } = useAuth();

  const [error, setError] = useState<string>();

  const [profession, setProfession] = useState<string>();
  const [lookingForWork, setLookingForWork] = useState<boolean>(true);

  const [leftSalaryBorder, setLeftSalaryBorder] = useState<number>();
  const [rightSalaryBorder, setRightSalaryBorder] = useState<number>();

  const [grade, setGrade] = useState<OptionContainer[]>([]);
  const gradeOptions: OptionContainer[] = Object.entries(GradeToString).flatMap(
    ([id, name]: [string, string]) => ({ label: name, value: Number(id) }),
  );

  const [telegram, setTelegram] = useState<string | undefined>();
  const [email, setEmail] = useState<string | undefined>();

  const [about, setAbout] = useState<string>();

  const saveResume = () => {
    const resume: ResumeProfile = {
      profession: profession!,
      lookingForWork: lookingForWork,
      leftSalaryBorder: leftSalaryBorder!,
      rightSalaryBorder: rightSalaryBorder!,
      telegram: telegram ? telegram : undefined,
      email: email ? email : undefined,
      grade: grade[0].value,
      about: about,
    };

    api
      .post("resumes/me", resume)
      .then(() => navigate("resumes/me"))
      .catch(() => setError("Возникла ошибка"));
  };

  if (user == null) navigate("/login");

  return (
    <Feed style={{ paddingBottom: "1.5rem", width: "40vw" }}>
      <Container>
        <h2>Резюме</h2>
        <div className={classes.verticalGroup}>
          {error != null && error != "" && (
            <span className={classes.error}>{error}</span>
          )}
          <CustomInput
            placeholder="вакансия, на которую вы претендуете"
            value={profession}
            onChange={(e: any) => setProfession(e.target.value)}
          />
          <div className={classes.checkboxGroup}>
            <Checkbox
              checked={lookingForWork}
              onChange={(e: any) => setLookingForWork(e.target.checked)}
            />
            <p>Ищу работу</p>
          </div>
          <CustomInput
            type="number"
            step="1"
            placeholder="левая граница вилки"
            value={leftSalaryBorder}
            onChange={(e: any) => setLeftSalaryBorder(Number(e.target.value))}
          />
          <CustomInput
            type="number"
            step="1"
            placeholder="правая граница вилки"
            value={rightSalaryBorder}
            onChange={(e: any) => setRightSalaryBorder(Number(e.target.value))}
          />
          <StyledSelect
            values={grade}
            options={gradeOptions}
            onChange={(values: OptionContainer[]) => {
              console.log(values);
              setGrade(values);
            }}
          />
          <CustomInput
            placeholder="ссылка на telegram"
            value={telegram}
            onChange={(e: any) => setTelegram(e.target.value)}
          />
          <CustomInput
            placeholder="почта для связи"
            value={email}
            onChange={(e: any) => setEmail(e.target.value)}
          />
          <CustomTextArea
            style={{ minHeight: "15rem" }}
            placeholder="Расскажите о себе"
            value={about}
            onChange={(e: any) => setAbout(e.target.value)}
          />
          <button onClick={saveResume}>Сохранить</button>
        </div>
      </Container>
    </Feed>
  );
}
