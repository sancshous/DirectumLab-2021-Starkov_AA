import * as React from "react";
import HistoryHeader from "./history-header/history-header";
import Story from "./story/story";
import Modal from "../modal/modal";
import {IDiscussion, IRoom} from "../../store/types";
import remove from "../../images/remove.svg";
import Button from "../button/button";
import "./history.css";

interface IProps {
  defaultState: IDiscussion | undefined,
  room: IRoom | null
}

interface IState {
  modalInfo: IDiscussion | undefined
}

class History extends React.Component<IProps, IState> {

  constructor(props: IProps) {
    super(props);
    this.state = {
      modalInfo: props.defaultState
    }
    this.handleClickOpen = this.handleClickOpen.bind(this);
    this.handleClickClose = this.handleClickClose.bind(this);
  }

  handleClickOpen = (discussionId: string) => {
    this.setState( {
      modalInfo: this.props.room?.discussions.find((d) => d.id == discussionId)
    });
  }

  handleClickClose = () => {
    this.setState( {
      modalInfo: undefined
    });
  }


  render() {
    const {modalInfo} = this.state;
    return <div className="history">
      <HistoryHeader mark={this.props.room?.discussions.filter((d) => d.end != null).length} />
      {modalInfo != undefined && <Modal room={this.props.room} discussion={modalInfo} onClick={this.handleClickClose} /> }
      <table id={'tableH'} className="history__body">
        {
          this.props.room?.discussions.map((d) => d.end != null && (
            // eslint-disable-next-line react/jsx-key
            <div className={'history__story__body'}>
              <Story discussionId={d.id} onClick={this.handleClickOpen} key={d.id} title={d.title} average={d.averageVote} />
              <Button onClick={undefined} className={'history__story-btnDelete'} title={<img src={remove} />} />
            </div>
          ))
        }
      </table>
    </div>
      ;
  }
}

export default History;
