import {IRootState} from "../../store/types";
import {compose, Dispatch} from "redux";
import * as React from "react";
import {withRouter} from "react-router-dom";
import {connect} from "react-redux";
import RoomPageView from "./room-page-view";
import {updateRoomOperation} from "../../store/room/room-operations";
import {createDiscussionOperation, updateDiscussionsOperation} from "../../store/discussion/discussion-operations";

const mapStateToProps = (state: IRootState) => {
  return{
    user: state.user,
    room: state.room,
    //discussions: state.discussions,
    cards: state.cards,
    state: state
  };
};

const mapDispatchToProps = (dispatch: Dispatch) => {
  return {
    createDiscussion: async (roomId: string) => {
      return dispatch(await createDiscussionOperation(roomId))
    },
    updateRoom: async (roomId: string) => {
      return dispatch(await updateRoomOperation(roomId))
    },
    updateDiscussions: async (roomId: string) => {
      return dispatch(await updateDiscussionsOperation(roomId));
    },
    getRoomInfo: async (roomId: string) => {
      return compose(dispatch(updateRoomOperation(roomId)), dispatch(updateDiscussionsOperation(roomId)));
    }
  };
}

export default compose<React.ComponentClass>(withRouter, connect(mapStateToProps, mapDispatchToProps))(RoomPageView);
