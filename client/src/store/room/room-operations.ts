import {Dispatch} from "redux";
import {IRoom, IRootState, IUser} from "../types";
import {updateUser} from "../user/user-action-creators";
import {
  addVoteRequest,
  createRoomRequest,
  getRoomInfoRequest
} from "../../api/poker-api";
import {updateRoom} from "./room-action-creators";

export const createRoomOperation = (userName: string, roomName: string): any => {
  return async (dispatch: Dispatch, getState: () => IRootState): Promise<string | void> => {
    const response = await createRoomRequest(userName, roomName);
    if (response != null) {
        const user: IUser = { name: response?.users[0].name, id: response?.users[0].id };
        dispatch(updateUser(user));
        dispatch(updateRoom(response));
        return response?.id;
      }
  }
}

export const updateRoomOperation = (roomId: string): any => {
  return async (dispatch: Dispatch, getState: () => IRootState): Promise<IRoom | null> => {
    const response = await getRoomInfoRequest(roomId);
    if(response != null) {
      dispatch(updateRoom(response));
      return response;
    }
    return null;
  }
}

export const addVoteOperation = (cardId: string, userId: string, discussionId: string): any => {
  return async (dispatch: Dispatch, getState: () => IRootState) => {
    const response = await addVoteRequest(cardId, userId, discussionId);
  }
}
