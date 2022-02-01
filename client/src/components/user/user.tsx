import * as React from "react";
import user from '../../images/user.svg';
import {Link} from "react-router-dom";
import {RoutePath} from "../../routes";
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
      <Link className="user__details-text" to={RoutePath.INDEX}>Sign Out</Link>
    </div>
  </details>
    ;
}

export default User;
