import * as React from "react";
import ModalPlayer from "./modal-player/modal-player";
import "./modal.css";

interface IProps {
  onSubmit: () => void
}

const ModalContent: React.FC<IProps> = (props) => {
  return <div className="modal__content">
    <p className="modal-header">Story Details</p>
    <h2 className="modal-Players">FirstStatePlayers:</h2>
    <table className="modal__players-group">
      <ModalPlayer name={'Dima'} value={10} />
      <ModalPlayer name={'Masha'} value={18} />
    </table>
    <button onClick={props.onSubmit} className="modal__btn-close">Close</button>
  </div>
}

export default ModalContent;
