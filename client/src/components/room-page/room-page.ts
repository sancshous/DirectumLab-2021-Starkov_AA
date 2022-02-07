import {IRoom, IRootState} from "../../store/types";
import {compose, Dispatch} from "redux";
import * as React from "react";
import {withRouter} from "react-router-dom";
import {connect} from "react-redux";
import RoomPageView from "./room-page-view";
import {updateRoom} from "../../store/room/room-action-creators";

const mapStateToProps = (state: IRootState) => {
  return{
    user: state.user,
    room: state.room
  };
};

const mapDispatchToProps = (dispatch: Dispatch) => {
  return {
    updateRoom: (room: IRoom) => {
      dispatch(updateRoom(room));
    }
  };
}

export default compose<React.ComponentClass>(withRouter, connect(mapStateToProps, mapDispatchToProps))(RoomPageView);
