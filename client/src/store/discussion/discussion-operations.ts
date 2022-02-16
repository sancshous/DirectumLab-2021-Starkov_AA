import {Dispatch} from "redux";
import {IDiscussion, IRootState} from "../types";
import {createDiscussionRequest, getDiscussionListRequest} from "../../api/poker-api";
import {updateDiscussionsAction} from "./discussion-action-creators";

export const createDiscussionOperation = (roomId: string): any => {
  return async (dispatch: Dispatch, getState: () => IRootState) => {
    const responseDiscussion = await createDiscussionRequest(roomId);
    const response = await getDiscussionListRequest(roomId);
    if (responseDiscussion != null && response != null) {
      dispatch(updateDiscussionsAction(response));
    }
  }
}

export const updateDiscussionsOperation = (roomId: string): any => {
  return async (dispatch: Dispatch, getState: () => IRootState): Promise<IDiscussion[] | null> => {
    const response = await getDiscussionListRequest(roomId);
    if (response != null) {
      dispatch(updateDiscussionsAction(response));
      return await response;
    }
    return null;
  }
}
