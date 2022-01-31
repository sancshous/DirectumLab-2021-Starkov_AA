import * as React from "react";
import user from "../../images/user.svg";
import "./modal.css";

interface IProps {
  className?: string | null
}

interface IState {
  isOpened: boolean
}

class Modal extends React.Component<IProps, IState>{

  constructor(props: IProps) {
    super(props);
    this.state = {
      isOpened: false
    }
  }

  render() {
    return <div className={`modal__wrapper ${this.props.className || ''}`}>
      <div className="modal__content">
        <p className="modal-header">Story Details</p>
        <h2 className="modal-Players">FirstStatePlayers:</h2>
        <table className="modal__players-group">
          <tr className="modal__player">
            <td><img className="modal__player-icon" src={user} alt="player" /></td>
            <td className="modal__player-name">test</td>
            <td className="modal__player-value">3</td>
          </tr>
          <tr className="modal__player">
            <td><img className="modal__player-icon" src={user} alt="player" /></td>
            <td className="modal__player-name">test 2</td>
            <td className="modal__player-value">8</td>
          </tr>
        </table>
        <button className="modal__btn-close">Close</button>
      </div>
    </div>
      ;
  }
}

export default Modal;
