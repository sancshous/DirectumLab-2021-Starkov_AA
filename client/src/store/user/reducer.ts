import {IUser} from "../types";
import {IUpdateUserAction} from "./user-action-creators";
import {ActionType} from "../reducer";

export const reducer = (state: IUser | null = null, action: IUpdateUserAction): IUser | null => {
  switch (action.type) {
    case ActionType.UPDATE_USER: {
      return {
        ...action.user
      };
    }
    case ActionType.CLEAR: {
      return null;
    }
    default:
      return state;
  }
}
