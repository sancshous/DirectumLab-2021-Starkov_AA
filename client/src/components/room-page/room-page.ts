import {IRootState} from "../../store/types";
import {compose, Dispatch} from "redux";
import * as React from "react";
import {withRouter} from "react-router-dom";
import {connect} from "react-redux";
import RoomPageView from "./room-page-view";
import {addVoteOperation, updateRoomOperation} from "../../store/room/room-operations";
import {
  closeDiscussionOperation,
  createDiscussionOperation,
  deleteDiscussionOperation
} from "../../store/discussion/discussion-operations";
import {getCardsOperation} from "../../store/cards/card-operation";
import {searchUserOperation} from "../../store/user/user-operations";

const mapStateToProps = (state: IRootState) => {
  return{
    user: state.user,
    room: state.room,
    cards: state.cards
  };
};

const mapDispatchToProps = (dispatch: Dispatch) => {
  return {
    createDiscussion: async (roomId: string, title: string) => {
      return dispatch( await createDiscussionOperation(roomId, title))
    },
    closeDiscussion: async (discussionId: string, roomId: string) => {
      return dispatch( await closeDiscussionOperation(discussionId, roomId))
    },
    deleteDiscussion: async (roomId: string, discussionId: string) => {
      return dispatch( await deleteDiscussionOperation(roomId, discussionId))
    },
    updateRoom: async (roomId: string) => {
      return dispatch( await updateRoomOperation(roomId))
    },
    loadCards: async () => {
      return dispatch(await getCardsOperation())
    },

    searchUser: async (userId: string, roomId: string) => {
      return dispatch(await searchUserOperation(userId, roomId));
    },

    addVote: async (cardId: string, userId: string, discussionId: string) => {
      return dispatch(await addVoteOperation(cardId, userId, discussionId));
    }
  };
}

export default compose<React.ComponentClass>(withRouter, connect(mapStateToProps, mapDispatchToProps))(RoomPageView);
