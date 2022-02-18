import * as React from "react";
import HistoryHeader from "./history-header/history-header";
import Story from "./story/story";
import Modal from "../modal/modal";
import {IRoom} from "../../store/types";
import "./history.css";

interface IProps {
  defaultState: boolean,
  room: IRoom | null
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
      <HistoryHeader mark={this.props.room?.discussions.filter((d) => d.end != null).length} />
      <table className="history__body">
        {
          this.props.room?.discussions.map((d) => d.end != null && (
            // eslint-disable-next-line react/jsx-key
            <div>
              {showModal && <Modal room={this.props.room} discussion={d} onClick={this.handleClickClose} /> }
              <Story discussionId={d.id} onClick={this.handleClickOpen} key={d.id} title={d.title} average={d.averageVote} />
            </div>
          ))
        }
      </table>
    </div>
      ;
  }
}

export default History;
