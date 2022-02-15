import {Action} from "redux";
import {IDiscussion} from "../types";
import {ActionType} from "../reducer";

export interface IUpdateDiscussionAction extends Action {
  discussions: IDiscussion[]
}

export const updateDiscussionsAction = (discussions: IDiscussion[]) => {
  return {
    type: ActionType.UPDATE_DISCUSSIONS,
    discussions
  };
}
