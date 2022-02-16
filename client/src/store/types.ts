export type UserId = string;

type CardValue = string;

export interface IUser {
  id: UserId,
  name: string
}

export interface IDiscussion {
  id: string,
  name: string,
  roomId: string,
  average: number | null,
  start: Date,
  end: Date,
  votes: Array<IVote>
}

export interface IRoom {
  id: string,
  name: string,
  ownerId: UserId,
  users: Array<IUser>,
  cards: Array<string>,
  discussions: Array<IDiscussion>
}

export interface ICard {
  id: string,
  value: number,
  title: string
}

export interface IVote {
  id: string,
  card: ICard,
  userId: string
}

export  interface IRootState {
  room: IRoom | null,
  user: IUser | null,
  //discussions: Array<IDiscussion>,
  cards: Array<ICard> | null,
  loading: boolean
}
