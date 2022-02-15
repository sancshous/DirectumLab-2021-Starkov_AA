import * as React from "react";
import HistoryHeader from "./history-header/history-header";
import Story from "./story/story";
import Modal from "../modal/modal";
import "./history.css";
import {store} from "../../store/mockStore";

interface IProps {
  defaultState: boolean
}

interface IState {
  showModal: boolean
}

class History extends React.Component<IProps, IState> {

  constructor(props: IProps) {
    super(props);
    this.state = {
      showModal: props.defaultState
    }
    this.handleClickOpen = this.handleClickOpen.bind(this);
    this.handleClickClose = this.handleClickClose.bind(this);
  }

  handleClickOpen = () => {
    this.setState( {
      showModal: true
    });
  }

  handleClickClose = () => {
    this.setState( {
      showModal: false
    });
  }


  render() {
    const {showModal} = this.state;
    return <div className="history">
      {showModal && <Modal onClick={this.handleClickClose} /> }
      <HistoryHeader mark={store.room?.discussions.length} />
      <table className="history__body">
        {
          store.room?.discussions.map((story) => (
            <Story onClick={this.handleClickOpen} key={story.id} title={story.name} average={story.average} />
          ))
        }
      </table>
    </div>
      ;
  }
}

export default History;
