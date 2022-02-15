import {Action} from "redux";
import {ICard} from "../types";
import {ActionType} from "../reducer";

export interface ICardsAction extends Action {
  cards: ICard[]
}

export const cardAction = (cards: ICard[]) => {
  return {
    type: ActionType.LOAD_CARDS,
    cards
  }
}
