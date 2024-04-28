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
}

// при создании трэда создать дерево комментариев, 
// добавлять детей на клиенте, затем сделать отображение через bfs