import {combineReducers} from 'redux';
import {reducer as userReducer } from './user/reducer';
import {reducer as roomReducer } from './room/reducer';
import {reducer as historyReducer } from './history/reducer';

export const ActionType = {
  UPDATE_ROOM: 'UPDATE_ROOM',
  UPDATE_USER: 'UPDATE_USER',
  CLEAR: 'CLEAR',
  ADD_INTO_HISTORY: 'ADD_INTO_HISTORY'
}

export const reducer = combineReducers({
  user: userReducer,
  room: roomReducer,
  history: historyReducer
});

export const cleanActionCreator = () => {
  return {
    type: ActionType.CLEAR
  }
}
