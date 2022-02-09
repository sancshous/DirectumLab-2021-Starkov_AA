import {IRoom, IRootState, IStory} from "../../store/types";
import {compose, Dispatch} from "redux";
import * as React from "react";
import {withRouter} from "react-router-dom";
import {connect} from "react-redux";
import RoomPageView from "./room-page-view";
import {updateRoom} from "../../store/room/room-action-creators";
import {addIntoHistory} from "../../store/history/history-action-creators";

const mapStateToProps = (state: IRootState) => {
  return{
    user: state.user,
    room: state.room,
    history: state.historyTEST
  };
};

const mapDispatchToProps = (dispatch: Dispatch) => {
  return {
    updateRoom: (room: IRoom) => {
      dispatch(updateRoom(room));
    },
    addIntoHistory: (story: IStory) => {
      dispatch(addIntoHistory(story))
    }
  };
}

export default compose<React.ComponentClass>(withRouter, connect(mapStateToProps, mapDispatchToProps))(RoomPageView);
