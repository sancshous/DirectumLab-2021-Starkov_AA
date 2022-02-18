import {Dispatch} from "redux";
import {ICard, IRootState} from "../types";
import {getCardsRequest} from "../../api/poker-api";
import {cardAction} from "./cards-action-creators";

export const getCardsOperation = (): any => {
  return async (dispatch: Dispatch, getState: () => IRootState): Promise<ICard[] | null> => {
    const response = await getCardsRequest();
    if (response != null) {
      dispatch(cardAction(response));
      return await response;
    }
    return null;
  }
}
