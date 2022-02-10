import {Action} from "redux";
import {IStory} from "../types";
import {ActionType} from "../reducer";

export interface IUpdateHistoryAction extends Action {
  story: IStory
}

export const addIntoHistory = (story: IStory) => {
  return {
    type: ActionType.ADD_INTO_HISTORY,
    story
  };
}
