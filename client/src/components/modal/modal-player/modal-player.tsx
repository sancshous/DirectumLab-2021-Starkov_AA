import * as React from "react";
import user from "../../../images/user.svg";
import "./modal-player.css";

interface IProps {
  name: string | undefined,
  value: number
}

const ModalPlayer: React.FC<IProps> = (props) => {
  return <tr className="modal__player">
    <td><img className="modal__player-icon" src={user} alt="player" /></td>
    <td className="modal__player-name">{props.name}</td>
    <td className="modal__player-value">{props.value}</td>
  </tr>
}

export default ModalPlayer;
