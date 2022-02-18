import {ICard} from "../types";
import {ActionType} from "../reducer";
import {ICardsAction} from "./cards-action-creators";

export const reducer = (state: ICard[] | null = null, action: ICardsAction): ICard[] | null => {
  switch (action.type) {
    case ActionType.LOAD_CARDS: {
      return {
        ...action.cards
      };
    }
    case ActionType.CLEAR: {
      return null;
    }
    default:
      return state;
  }
}
