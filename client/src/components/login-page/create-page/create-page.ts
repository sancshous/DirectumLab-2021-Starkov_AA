import {compose, Dispatch} from "redux";
import {createRoomOperation} from "../../../store/room/room-operations";
import * as React from "react";
import {withRouter} from "react-router-dom";
import {connect} from "react-redux";
import CreatePageView from "./create-page-view";

const mapDispatchToProps = (dispatch: Dispatch) => {
  return {
    createRoom: async (userName: string, roomName: string) => {
      return dispatch(await createRoomOperation(userName, roomName));
    }
  }
}

export default compose<React.ComponentClass>(withRouter, connect(null, mapDispatchToProps))(CreatePageView);
