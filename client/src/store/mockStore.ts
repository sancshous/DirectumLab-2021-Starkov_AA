import {IRoom, IUser, IRootState, IStory} from "./types";

export const store: IRootState = {
  user: null,
  room: null,
  historyStory: [],
  loading: false
};

export const user: IUser = {
  id: '',
  name: ''
};

export const room: IRoom = {
  id: '',
  name: '',
  cards: ['0', '0.5', '1', '2', '3', '5', '8', '13', '20', '40', '100', '-10', '-100'],
  ownerId: '',
  users: [],
  stories: []
};

export const story: IStory = {
  id: '',
  name: '',
  average: null,
  votes: {}
};
