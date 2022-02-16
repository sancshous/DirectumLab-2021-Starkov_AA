import {Dispatch} from "redux";
import {IRoom, IRootState, IVote} from "../types";
import {updateUser} from "../user/user-action-creators";
import {toggleIndicator} from "../loading/reducer";
import {
  addVoteRequest,
  createRoomRequest,
  getRoomInfoRequest
} from "../../api/poker-api";
import {updateRoom} from "./room-action-creators";

export const createRoomOperation = (userName: string, roomName: string): any => {
  return async (dispatch: Dispatch, getState: () => IRootState): Promise<string | void> => {
    dispatch(toggleIndicator(true));
    try {
      const response = await createRoomRequest(userName, roomName);
      dispatch(updateUser(response.users[0]));
      dispatch(updateRoom(response));
      return response?.id;
    }
    catch (e) {
      window.console.log(e);
    }
    finally {
      dispatch(toggleIndicator(false));
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
