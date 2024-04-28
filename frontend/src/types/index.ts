export type Author = {
    nickname: string;
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
    firstName: string;
    lastName: string;
    gender: number;
    avatar: string | null;
    email: string;
};

export const getProfileName = (profile: Profile) =>
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
    name: string;
    profession: string;
    lookingForWork: boolean;
    leftSalaryBorder: number;
    rightSalaryBorder: number;
    grade: Grade;
};

export type ResumeProfile = {
    header: ResumeThumbnail;
    workPlaces: WorkPlace[];
    about: string;
}

export type WorkPlace = {
    companyName: string;
    grade: Grade;
    description: string;
    dateBegin: Date;
    dateEnd: Date;
}

export enum Grade {
    Intern,
    Junior,
    Middle,
    Senior
};

export const GradeToString = {
    [Grade.Intern]: 'Стажер',
    [Grade.Junior]: 'Младший',
    [Grade.Middle]: 'Средний',
    [Grade.Senior]: 'Старший',
}