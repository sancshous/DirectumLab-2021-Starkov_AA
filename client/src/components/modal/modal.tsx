import * as React from "react";
import ModalContent from "./modal-content";
import "./modal.css";

interface IProps {
  onClick: () => void
}

const Modal: React.FC<IProps> = (props) => {
  return <div className={`modal__wrapper`}>
    <ModalContent onSubmit={props.onClick} />
  </div>
    ;
}

export default Modal;
