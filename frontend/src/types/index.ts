export type Author = {
    username: string;
    avatarLink: string;
};

export type Thread = {
    id: number;
    name: string;
};

export type Tag = {
    id: number;
    name: string;
};

export type Article = {
    id: number;
    author: Author;
    title: string;
    text: string;
    thread: Thread;
    tags: Tag[];
    karma: number;
};

export type ArticleThumbnail = {
    id: number;
    title: string;
};

export type Profile = {
    username: string;
    firstName: string;
    lastName: string;
    avatarLink: string | null;

    articles: Article[];
    tags: Tag[];
};

export const getProfileName = (profile: Profile | ResumeThumbnail) =>
    profile.firstName + " " + profile.lastName;

export type Commentary = {
    id: number;
    parent_id?: number;
    author: Author;
    text: string;
    datetime: Date;

    children?: Commentary[];
};

export type ResumeThumbnail = {
    avatarLink: string;
    firstName: string;
    lastName: string;
    profession: string;
    lookingForWork: boolean;
    leftSalaryBorder: number;
    rightSalaryBorder: number;
    grade: Grade;
};

export type ResumeProfile = ResumeThumbnail | {
    about: string;
    tags: Tag[],
    workPlaces: WorkPlace[];
};

export type WorkPlace = {
    companyName: string;
    profession: string;
    grade: Grade;
    description: string;
    dateBegin: Date;
    dateEnd: Date;
};

export enum Grade {
    Intern = 0,
    Junior,
    Middle,
    Senior
};

export const GradeToString = {
    [Grade.Intern]: 'Стажер',
    [Grade.Junior]: 'Младший',
    [Grade.Middle]: 'Средний',
    [Grade.Senior]: 'Старший',
};

export enum Gender {
    Male,
    Female
};
