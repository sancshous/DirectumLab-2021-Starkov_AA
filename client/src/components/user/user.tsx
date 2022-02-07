import * as React from "react";
import user from '../../images/user.svg';
import {Link} from "react-router-dom";
import {RoutePath} from "../../routes";
import {Dispatch} from "redux";
import {IUser} from "../../store/types";
import {cleanActionCreator} from "../../store/reducer";
import {connect} from "react-redux";
import './user.css';

interface IProps {
  name: string,
  updateUser: (user?: IUser) => void;
}

const User: React.FC<IProps> = (props) => {
  return <details className="user">
    <summary className="user__summary">
      <span className="user__name">{props.name}</span>
      <img className="user__icon" src={user} alt="user" />
    </summary>
    <div className="user__details">
      <Link className="user__details-text" to={RoutePath.INDEX} onClick={() => props.updateUser()}>Sign Out</Link>
    </div>
  </details>
    ;
}

const mapDispatchToProps = (dispatch: Dispatch) => {
  return {
    updateUser: (user?: IUser) => {
      dispatch(cleanActionCreator());
    }
  }
}

export default connect(null, mapDispatchToProps)(User);
