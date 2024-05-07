import { useEffect, useState } from "react";
import { GradeToString, OptionContainer, WorkPlace } from "../../../types";

import classes from "./companyEditor.module.css";
import { CustomInput, CustomTextArea } from "../../general";
import { StyledSelect } from "../../general/styledSelect";

export default function CompanyEditor({
  companyInfo,
  onCompanyChange,
  onSave,
}: {
  companyInfo: WorkPlace;
  onCompanyChange: (cmp: WorkPlace) => void;
  onSave: () => void;
}) {
  const [companyName, setCompanyName] = useState<string>(
    companyInfo.companyName,
  );

  const [profession, setProfession] = useState<string>(companyInfo.profession);
  const [grade, setGrade] = useState<OptionContainer[]>([
    {
      label: GradeToString[companyInfo.grade],
      value: companyInfo.grade,
    },
  ]);
  const gradeOptions: OptionContainer[] = Object.entries(GradeToString).flatMap(
    ([id, name]: [string, string]) => ({ label: name, value: Number(id) }),
  );

  const [dateBegin, setDateBegin] = useState<string>(
    parseDate(companyInfo.dateBegin)?.toLocaleDateString("en-CA"),
  );
  const [dateEnd, setDateEnd] = useState<string | null>(
    parseDate(companyInfo.dateEnd)?.toLocaleDateString("en-CA"),
  );
  const [description, setDescription] = useState<string>(
    companyInfo.description,
  );

  useEffect(
    () =>
      onCompanyChange({
        id: companyInfo.id,
        companyName: companyName,
        profession: profession,
        grade: grade.length > 0 ? grade[0].value : null,
        dateBegin: toApiDate(dateBegin),
        dateEnd: toApiDate(dateEnd),
        description: description,
      } as WorkPlace),
    [companyName, profession, grade, dateBegin, dateEnd, description],
  );

  return (
    <div className={classes.companyBlock}>
      <CustomInput
        value={companyName}
        placeholder="название компании"
        onChange={(e: any) => setCompanyName(e.target.value)}
      />
      <CustomInput
        value={profession}
        placeholder="должность"
        onChange={(e: any) => setProfession(e.target.value)}
      />
      <StyledSelect
        values={grade}
        options={gradeOptions}
        onChange={(values: OptionContainer[]) => {
          console.log(values);
          setGrade(values);
        }}
      />
      <div className={classes.datesGroup}>
        <div className={classes.dateRow}>
          <p style={{ textWrap: "nowrap" }}>дата начала:</p>
          <CustomInput
            style={{ width: "100%" }}
            type="date"
            value={dateBegin}
            onChange={(e: any) => setDateBegin(e.target.value!)}
          />
        </div>
        <div className={classes.dateRow}>
          <p style={{ textWrap: "nowrap" }}>дата конца:</p>
          <CustomInput
            style={{ width: "100%" }}
            type="date"
            value={dateEnd}
            onChange={(e: any) => setDateEnd(e.target.value)}
          />
        </div>
      </div>
      <CustomTextArea
        placeholder="чем занимались на проекте?"
        value={description}
        onChange={(e: any) => setDescription(e.target.value)}
      />
      <button className="alternative" onClick={onSave}>
        сохранить
      </button>
    </div>
  );
}

const parseDate = (date: string | null) => {
  if (date == null) return null;

  const dateParts = date.split(".");
  const formatedString = `${dateParts[2]}.${dateParts[0]}.${dateParts[1]}`;
  return new Date(Date.parse(formatedString));
};

const toApiDate = (date: string | null) => {
  if (date == null) return null;

  const dateF = new Date(date);
  const month =
    dateF.getMonth() < 10 ? `0${dateF.getMonth() + 1}` : dateF.getMonth();
  const dateSm = dateF.getDate() < 10 ? `0${dateF.getDate()}` : dateF.getDate();
  return `${month}.${dateSm}.${dateF.getFullYear()}`;
};
