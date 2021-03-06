import * as React from "react";
import './players-input.css';

const PlayersInput: React.FC = () => {
  return <label className="players__label">Invite a teammate
    <input className="players__input" type="text" readOnly={true} value={document.location.href} />
  </label>
    ;
}

export default PlayersInput;
