import {Action} from "redux";
import {IUser} from "../types";
import {ActionType} from "../reducer";

export interface IUpdateUserAction extends Action {
  user: IUser
}

export const updateUser = (user: IUser) => {
  return {
    type: ActionType.UPDATE_USER,
    user: user
  };
}
