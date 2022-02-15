import {IRoom, IUser, IRootState, IDiscussion} from "./types";

export const store: IRootState = {
  user: null,
  room: null,
  cards: [],
  //discussions: [],
  loading: false
};

export const user: IUser = {
  id: '',
  name: ''
};
