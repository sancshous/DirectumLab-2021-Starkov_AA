import {combineReducers} from 'redux';
import {reducer as userReducer } from './user/reducer';
import {reducer as roomReducer } from './room/reducer';
import {reducer as loadingReducer} from './loading/reducer';
import {reducer as cardsReducer} from './cards/reducer';

export const ActionType = {
  UPDATE_ROOM: 'UPDATE_ROOM',
  UPDATE_USER: 'UPDATE_USER',
  CLEAR: 'CLEAR',
  TOGGLE_INDICATOR: 'TOGGLE_INDICATOR',
  CREATE_DISCUSSION: 'CREATE_DISCUSSION',
  LOAD_CARDS: 'LOAD_CARDS'
}

export const reducer = combineReducers({
  user: userReducer,
  room: roomReducer,
  cards: cardsReducer,
  loading: loadingReducer,
});

export const cleanActionCreator = () => {
  return {
    type: ActionType.CLEAR
  }
}
