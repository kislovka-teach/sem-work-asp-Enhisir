export type Author = {
  userName: string;
  avatarLink: string;
};

export type Topic = {
  id: number;
  name: string;
};

export enum Topics {
  Development = 1,
  Administration,
  Design,
  Management,
  Marketing,
  Different,
}

export const TopicNames = {
  [Topics.Development]: "Разработка",
  [Topics.Administration]: "Администрирование",
  [Topics.Design]: "Дизайн",
  [Topics.Management]: "Менеджмент",
  [Topics.Marketing]: "Маркетинг",
  [Topics.Different]: "Разное",
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
  topic: Topic;
  tags: Tag[];
  karma: number;
  commentaries: Commentary[];
};

export type ArticleThumbnail = {
  id: number;
  title: string;
};

export type UserThumbnail = {
  userName: string;
  role: Role.User;
};

export enum Role {
  User,
  Admin,
}

export type Profile = {
  userName: string;
  firstName: string;
  lastName: string;
  avatarLink: string | null;

  articles: Article[];
  tags: Tag[];

  hasResume?: boolean;
  subscribed: boolean; 
};

export const getProfileName = (profile: Profile | ResumeThumbnailType) =>
  profile.firstName + " " + profile.lastName;

export type Commentary = {
  id: number;
  articleId: Number;
  parentId?: number;
  author: Author;
  text: string;
  datetime: Date;

  children?: Commentary[];
};

export type ResumeThumbnailType = {
  avatarLink: string;
  userName: string;
  firstName: string;
  lastName: string;
  profession: string;
  lookingForWork: boolean;
  leftSalaryBorder: number;
  rightSalaryBorder: number;
  grade: Grade;
};

export type ResumeProfile =
  | ResumeThumbnailType
  | {
      telegram?: string;
      email?: string;
      about: string;
      tags: Tag[];
      workPlaces: WorkPlace[];
    };

export type WorkPlace = {
  id: number;
  companyName: string;
  profession: string;
  grade: Grade;
  description: string;
  dateBegin: string;
  dateEnd: string | null;
};

export enum Grade {
  Intern = 0,
  Junior,
  Middle,
  Senior,
}

export const GradeToString = {
  [Grade.Intern]: "Стажер",
  [Grade.Junior]: "Младший",
  [Grade.Middle]: "Средний",
  [Grade.Senior]: "Старший",
};

export enum Gender {
  Male,
  Female,
}

export type OptionContainer = {
  label: string;
  value: any;
};

export const TagToOptionContainer = (tag: Tag): OptionContainer => ({
  label: tag.name,
  value: tag.id,
});

export const OptionContainerToTag = (opt: OptionContainer): Tag => ({
  id: opt.value,
  name: opt.label,
});
