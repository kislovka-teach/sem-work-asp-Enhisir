import { useEffect, useState } from "react";
import { useSearchParams } from "react-router-dom";

import { GradeToString, OptionContainer, Tag, TagToOptionContainer } from "../../../types"
import Container from "../../general/container";
import { StyledSelect } from "../../general/styledSelect";

import api from "../../../config/axios";
import classes from "./resumeFilter.module.css";
import { CustomInput } from "../../general";

function ResumeFilter() {
    const [searchParams, setSearchParams] = useSearchParams();
    const [avaliableOptions, setAvaliableOptions] = useState<OptionContainer[]>([]);
    const [addedOptions, setAddedOptions] = useState<OptionContainer[]>([]);
    const [searchString, setSearchString] = useState<string>("");
    const [leftSalaryBorder, setLeftSalaryBorder] = useState<number | undefined>();
    const [rightSalaryBorder, setRightSalaryBorder] = useState<number | undefined>();

    const [currentGradeOptions, setCurrentGradeOptions] = useState<OptionContainer[]>([]);
    const gradeOptions: OptionContainer[] = Object
        .entries(GradeToString)
        .flatMap(([id, name]: [string, string]) => ({ label: name, value: Number(id) }));

    const onSearch = ({ props, state, methods }: { props: any, state: any, methods: any }) => {
        console.log({ props, state, methods });

        setSearchString(state.search);

        const regexp = new RegExp(methods.safeString(state.search), 'i');
        return methods
            .sortBy()
            .filter((item: any) =>
                regexp.test(getByPath(item, props.searchBy) || getByPath(item, props.valueField))
            );
    };


    useEffect(() => {
        api.get("/resumes/tags" + (searchString ? `?name=${searchString}` : ''))
            .then(response => {
                setAvaliableOptions(response.data.flatMap((item: Tag) => TagToOptionContainer(item)))
            })
    }, [searchString]);

    useEffect(() => {
        let newSearchParams: { [param: string]: any } = {};
        if (searchParams.get("search")) newSearchParams["search"] = searchParams.get("search");
        if (leftSalaryBorder) newSearchParams["leftSalaryBorder"] = leftSalaryBorder;
        if (rightSalaryBorder) newSearchParams["rightSalaryBorder"] = rightSalaryBorder;
        if (currentGradeOptions.length > 0) newSearchParams["grade"] = currentGradeOptions[0].value;
        if (addedOptions.length > 0)
            newSearchParams["tags"] = addedOptions.flatMap((item: OptionContainer) => item.value);
        setSearchParams(newSearchParams, { replace: true });
    }, [addedOptions, leftSalaryBorder, rightSalaryBorder, currentGradeOptions]);

    return <Container>
        <h2>Фильтр</h2>
        <h4>Грейд</h4>
        <StyledSelect
            values={currentGradeOptions}
            options={gradeOptions}
            onChange={(values: OptionContainer[]) => {
                console.log(values);
                setCurrentGradeOptions(values)
            }} />
        <h4>Зарплатная вилка</h4>
        <div className={classes.priceRow}>
            <CustomInput type="number" value={leftSalaryBorder}
                onChange={(e: any) => setLeftSalaryBorder(e.target.value)} />
            <span style={{ fontWeight: 600, }}>{' - '}</span>
            <CustomInput type="number" value={rightSalaryBorder}
                onChange={(e: any) => setRightSalaryBorder(e.target.value)} />
        </div>
        <h4>Искать по тэгам</h4>
        <StyledSelect
            multi
            values={addedOptions}
            options={avaliableOptions}
            onChange={(values: OptionContainer[]) => {
                console.log("!");
                console.log(values);
                setAddedOptions(values)
            }}
            searchFn={onSearch}
            name="default" />
    </Container>;;
};

export default ResumeFilter;

const getByPath = (object: any, path: any) => {
    if (!path) return;

    return path.split('.').reduce((acc: any, value: any) => acc[value], object);
};