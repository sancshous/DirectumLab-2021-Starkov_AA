import {combineReducers} from 'redux';
import {reducer as userReducer } from './user/reducer';
import {reducer as roomReducer } from './room/reducer';

export const ActionType = {
  UPDATE_ROOM: 'UPDATE_ROOM',
  UPDATE_USER: 'UPDATE_USER',
  CLEAR: 'CLEAR'
}

export const reducer = combineReducers({
  user: userReducer,
  room: roomReducer
});

export const cleanActionCreator = () => {
  return {
    type: ActionType.CLEAR
  }
}
