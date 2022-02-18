import * as React from "react";
import ModalContent from "./modal-content";
import {IDiscussion, IRoom} from "../../store/types";
import "./modal.css";

interface IProps {
  onClick: () => void,
  discussion: IDiscussion | null,
  room: IRoom | null
}

const Modal: React.FC<IProps> = (props) => {
  return <div className={`modal__wrapper`}>
    <ModalContent room={props.room} discussion={props.discussion} onSubmit={props.onClick} />
  </div>
    ;
}

export default Modal;
