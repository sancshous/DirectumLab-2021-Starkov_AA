import * as React from "react";
import ModalPlayer from "./modal-player/modal-player";
import {IDiscussion, IRoom} from "../../store/types";
import "./modal.css";

interface IProps {
  onSubmit: () => void,
  discussion: IDiscussion | null,
  room: IRoom | null
}

const ModalContent: React.FC<IProps> = (props) => {
  return <div className="modal__content">
    <p className="modal-header">Story Details</p>
    <h2 className="modal-Players">{props.discussion?.title}</h2>
    <table className="modal__players-group">
      {
        props.discussion?.votes.map((vote) => (
          <ModalPlayer
            key={vote.id}
            name={props.room?.users.find((u) => u.id == vote.userId)?.name}
            value={vote.card.value} />
        ))
      }
    </table>
    <button onClick={props.onSubmit} className="modal__btn-close">Close</button>
  </div>
}

export default ModalContent;
