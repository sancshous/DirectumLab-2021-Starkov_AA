import {IDiscussion} from "../types";
import {ActionType} from "../reducer";

export const updateDiscussionsAction = (discussions: IDiscussion[]) => {
  return {
    type: ActionType.CREATE_DISCUSSION,
    discussions
  };
}
