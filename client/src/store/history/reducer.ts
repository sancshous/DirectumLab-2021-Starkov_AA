import {IStory} from "../types";
import {ActionType} from "../reducer";
import {IUpdateHistoryAction} from "./history-action-creators";

export const reducer = (state: IStory | null = null, action: IUpdateHistoryAction): IStory | null => {
  switch (action.type) {
    case ActionType.ADD_INTO_HISTORY: {
      return {
        ...action.story
      };
    }
    default:
      return state;
  }
}
