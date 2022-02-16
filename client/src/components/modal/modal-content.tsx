import * as React from "react";
import ModalPlayer from "./modal-player/modal-player";
import {store, user} from "../../store/mockStore";
import "./modal.css";

interface IProps {
  onSubmit: () => void
}

const ModalContent: React.FC<IProps> = (props) => {
  return <div className="modal__content">
    <p className="modal-header">Story Details</p>
    <h2 className="modal-Players">FirstStatePlayers:</h2>
    <table className="modal__players-group">
      {
        store.room?.discussions?.map((story) => (
          <ModalPlayer
            key={story.votes[0].id}
            name={store.user?.id == (Object.keys(story.votes) as Array<string>).find(key => story.votes[0]) && store.user?.name}
            value={+story.votes[0].userId} />
        ))
      }
    </table>
    <button onClick={props.onSubmit} className="modal__btn-close">Close</button>
  </div>
}

export default ModalContent;
