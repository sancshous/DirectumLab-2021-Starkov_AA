import {Dispatch} from "redux";
import {IRootState} from "../types";
import {updateUser} from "../user/user-action-creators";
import {toggleIndicator} from "../loading/reducer";
import {createRoomRequest} from "../../api/poker-api";

export const createRoom = (userName: string, roomName: string): any => {
  return async (dispatch: Dispatch, getState: () => IRootState): Promise<string | void> => {
    dispatch(toggleIndicator(true));
    try {
      const response = await createRoomRequest(userName, roomName);
      dispatch(updateUser(response.user));
      return response.roomId;
    }
    catch (e) {
      window.console.log(e);
    }
    finally {
      dispatch(toggleIndicator(false));
    }
  }
}
