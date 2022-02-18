import {Dispatch} from "redux";
import {IRoom, IRootState, IUser} from "../types";
import {addUserRequest, createUserRequest, searchUserRequest} from "../../api/poker-api";
import {updateUser} from "./user-action-creators";
import {updateRoom} from "../room/room-action-creators";

export const inviteUserOpearation = (userName: string, roomId: string): any => {
  return async (dispatch: Dispatch, getState: () => IRootState): Promise<IRoom | null> => {
    const responseUser = await createUserRequest(userName);
    if (responseUser != null) {
      const responseRoom = await addUserRequest(roomId, responseUser.id);
      if (responseRoom != null) {
        dispatch(updateUser(responseUser));
        dispatch(updateRoom(responseRoom));
        return responseRoom;
      }
      return null;
    }
    return null;
  };
};

export const searchUserOperation = (userId: string, roomId: string): any => {
  return async (dispatch: Dispatch, getState: () => IRootState): Promise<IUser | null> => {
    const responseUser = await searchUserRequest(userId, roomId);
    if (responseUser != null) {
      dispatch(updateUser(responseUser));
      return responseUser;
    }
    return null;
  };
};
