import {Dispatch} from "redux";
import {IRootState} from "../types";
import {closeDiscussionRequest, createDiscussionRequest, getDiscussionListRequest} from "../../api/poker-api";
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

export const closeDiscussionOperation = (discussionId: string, roomId: string): any => {
  return async (dispatch: Dispatch, getState: () => IRootState) => {
    const responseDiscussion = await closeDiscussionRequest(discussionId);
    const response = await getDiscussionListRequest(roomId);
    if (responseDiscussion != null && response != null) {
      dispatch(updateDiscussionsAction(response));
    }
  }
}
