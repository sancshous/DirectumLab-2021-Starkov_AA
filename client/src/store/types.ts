type UserId = string;

type CardValue = string;

export interface IUser {
  id: UserId,
  name: string
}

export interface IStory {
  id: string,
  name: string,
  average: number | null,
  votes: Record<UserId, CardValue>
}

export interface IRoom {
  id: string,
  name: string,
  cards: Array<CardValue>,
  ownerId: UserId,
  users: Array<IUser>,
  stories: Array<IStory>
}

export  interface IRoomState {
  room: IRoom | null,
  user: IUser | null
}
