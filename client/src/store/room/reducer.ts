import {IRoom} from "../types";
import {IUpdateRoomAction} from "./room-action-creators";
import {ActionType} from "../reducer";

export const reducer = (state: IRoom | null = null, action: IUpdateRoomAction): IRoom | null => {
  switch (action.type) {
    case ActionType.UPDATE_ROOM: {
      return {
        ...action.room
      };
    }
    case ActionType.CLEAR: {
      return null;
    }
    default:
      return state;
  }
}
