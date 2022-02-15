import {IDiscussion} from "../types";
import {ActionType} from "../reducer";
import {IUpdateDiscussionAction} from "./discussion-action-creators";

export const reducer = (state: IDiscussion[] | null = null, action: IUpdateDiscussionAction): IDiscussion[] | null => {
  switch (action.type) {
    case ActionType.UPDATE_DISCUSSIONS: {
      return {
        ...action.discussions
      };
    }
    case ActionType.CLEAR: {
      return null;
    }
    default:
      return state;
  }
}
