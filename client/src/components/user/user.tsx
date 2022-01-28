import * as React from "react";
import user from '../../images/user.svg';
import './user.css';

interface IProps {
  name: string
}

const User: React.FC<IProps> = (props) => {
  return <details className="user">
    <summary className="user__summary">
      <span className="user__name">{props.name}</span>
      <img className="user__icon" src={user} alt="user" />
    </summary>
    <div className="user__details">
      <a className="user__details-text" href="#">Sign Out</a>
    </div>
  </details>
    ;
}

export default User;
