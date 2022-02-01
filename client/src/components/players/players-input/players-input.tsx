import * as React from "react";
import './players-input.css';

interface IProps {
  onSubmit: () => void;
}

const PlayersInput: React.FC<IProps> = (props) => {
  return <label className="players__label">Invite a teammate
    <input onClick={props.onSubmit} className="players__input" type="text" readOnly={true} value={document.location.href} />
  </label>
    ;
}

export default PlayersInput;
