import {Action} from "redux";
import {IRoom} from "../types";
import {ActionType} from "../reducer";

export interface IUpdateRoomAction extends Action {
  room: IRoom
}

export const updateRoom = (room: IRoom) => {
  return {
    type: ActionType.UPDATE_ROOM,
    room: room
  };
}
