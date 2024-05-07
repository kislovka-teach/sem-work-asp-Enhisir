import { useNavigate } from "react-router-dom";
import { useAuth } from "../../auth";
import { useEffect, useState } from "react";
import {
  Grade,
  GradeToString,
  OptionContainer,
  ResumeProfile,
  WorkPlace,
} from "../../types";
import Feed from "../../components/general/feed";
import Container from "../../components/general/container";
import { CustomInput, CustomTextArea } from "../../components/general";
import { Checkbox } from "@mui/material";
import { StyledSelect } from "../../components/general/styledSelect";

import classes from "./editResume.module.css";
import CompanyEditor from "../../components/resume/companyEditor/companyEditor";
import DeleteButton from "../../components/general/deleteButton";
import api from "../../config/axios";
import CustomBeatLoader from "../../components/beatLoader";

export default function EditResumePage() {
  const navigate = useNavigate();

  const { user } = useAuth();

  const [loading, setLoading] = useState<boolean>(true);
  const [resumeInfo, setResumeInfo] = useState<ResumeProfile | null>();

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

  // const [tags, setTags] = useState<Tag[]>([]);

  const [workplaces, setWorkplaces] = useState<WorkPlace[]>([
    {
      companyName: "",
      profession: "",
      grade: null,
      description: "",
      dateBegin: null,
      dateEnd: null,
    },
  ]);

  useEffect(() => {
    setLoading(true);
    api
      .get("resumes/me")
      .then((response) => {
        console.log(response.data);
        setResumeInfo(response.data);
        setProfession(response.data.profession);
        setLookingForWork(response.data.lookingForWork);
        setLeftSalaryBorder(response.data.leftSalaryBorder);
        setRightSalaryBorder(response.data.rightSalaryBorder);
        setGrade([
          {
            label: GradeToString[response.data.grade as Grade],
            value: response.data.grade,
          },
        ]);
        setTelegram(response.data.telegram);
        setEmail(response.data.email);
        setAbout(response.data.about);
        setWorkplaces(response.data.workPlaces);
      })
      .catch(() => setResumeInfo(null))
      .finally(() => setLoading(false));
  }, []);

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
      .put("resumes/me", resume)
      .then(() => navigate(0))
      .catch(() => {});
  };

  if (user == null) navigate("/login");

  if (loading) return <CustomBeatLoader />;

  if (resumeInfo == null)
    return (
      <Container style={{ width: "100%" }}>
        <h2>Резюме не найдено</h2>
      </Container>
    );

  const saveWorkPlace = (wp: WorkPlace) => {
    if (wp.id == null) {
      api
        .post("/resumes/workplaces/new", wp)
        .then(() => {
          navigate(0);
        })
        .catch(() => alert("!!!"));
    } else {
      wp.dateBegin = new Date(wp.dateBegin).toISOString();
      if (wp.dateEnd != null) wp.dateEnd = new Date(wp.dateEnd).toISOString();

      api
        .put(`/resumes/workplaces/${wp.id}`, wp)
        .then(() => {
          navigate(0);
        })
        .catch(() => alert("!!!"));
    }
  };

  const deleteWorkPlace = (wp: WorkPlace, index: number) => {
    const cloneArray = [...workplaces];
    cloneArray.splice(index, 1);
    setWorkplaces(cloneArray);

    if (wp.id == null) return;

    api
      .delete(`/resumes/workplaces/${wp.id}`)
      .then(() => {
        navigate(0);
      })
      .catch(() => alert("!!!"));
  };

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
      <Container>
        <h2>Места работы</h2>
        <div className={classes.verticalGroup}>
          <button
            onClick={() => {
              setWorkplaces([
                ...workplaces,
                {
                  companyName: "",
                  profession: "",
                  grade: null,
                  description: "",
                  dateBegin: null,
                  dateEnd: null,
                },
              ]);
            }}
          >
            добавить новое место работы
          </button>
          {workplaces.flatMap((cmp: WorkPlace, index: number) => (
            <div
              className={[classes.editableRow, classes.upperBorderBlock].join(
                " ",
              )}
              key={`company_${index}_${index + 1}`}
            >
              <CompanyEditor
                companyInfo={cmp}
                onCompanyChange={(cmpChanged: WorkPlace) => {
                  const newWorkPlaces = [...workplaces];
                  newWorkPlaces[index] = cmpChanged;
                  console.log(newWorkPlaces);
                  setWorkplaces(newWorkPlaces);
                }}
                onSave={() => saveWorkPlace(workplaces[index])}
              />
              <DeleteButton
                onClick={() => deleteWorkPlace(workplaces[index], index)}
              />
            </div>
          ))}
        </div>
      </Container>
    </Feed>
  );
}
