import {Action} from "redux";
import {ActionType} from "../reducer";

export interface IToggleIndicator extends Action {
  show: boolean
}

export const toggleIndicator = (show: boolean): IToggleIndicator => {
  return {
    type: ActionType.TOGGLE_INDICATOR,
    show: show
  };
};

export function reducer(state = false, action: IToggleIndicator): boolean {
  switch (action.type) {
    case ActionType.TOGGLE_INDICATOR:
      return action.show;
    default:
      return state;
  }
}
