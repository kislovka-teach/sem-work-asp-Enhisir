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