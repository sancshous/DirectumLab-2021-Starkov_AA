import {IRootState} from "../../store/types";
import {compose, Dispatch} from "redux";
import * as React from "react";
import {withRouter} from "react-router-dom";
import {connect} from "react-redux";
import RoomPageView from "./room-page-view";
import {addVoteOperation, updateRoomOperation} from "../../store/room/room-operations";
import {createDiscussionOperation, updateDiscussionsOperation} from "../../store/discussion/discussion-operations";
import {getCardsOperation} from "../../store/cards/card-operation";

const mapStateToProps = (state: IRootState) => {
  return{
    user: state.user,
    room: state.room,
    cards: state.cards
  };
};

const mapDispatchToProps = (dispatch: Dispatch) => {
  return {
    createDiscussion: async (roomId: string) => {
      return dispatch( await createDiscussionOperation(roomId))
    },
    updateRoom: async (roomId: string) => {
      return dispatch( await updateRoomOperation(roomId))
    },
    loadCards: async () => {
      return dispatch(await getCardsOperation())
    },
    updateDiscussions: async (roomId: string) => {
      return dispatch(await updateDiscussionsOperation(roomId));
    },

    addVote: async (cardId: string, userId: string, discussionId: string) => {
      return dispatch(await addVoteOperation(cardId, userId, discussionId));
    },

    getRoomInfo: async (roomId: string) => {
      return compose(dispatch(updateRoomOperation(roomId)), dispatch(updateDiscussionsOperation(roomId)));
    }
  };
}

export default compose<React.ComponentClass>(withRouter, connect(mapStateToProps, mapDispatchToProps))(RoomPageView);
