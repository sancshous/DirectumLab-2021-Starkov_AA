import {IDiscussion} from "../types";
import {ActionType} from "../reducer";
import {IUpdateRoomAction} from "../room/room-action-creators";

export const reducer = (state: IDiscussion[] | null = null, action: IUpdateRoomAction): IDiscussion[] | null => {
  switch (action.type) {
    case ActionType.UPDATE_DISCUSSIONS: {
      return {
        ...action.room.discussions
      };
    }
    case ActionType.CLEAR: {
      return null;
    }
    default:
      return state;
  }
}
