import * as React from "react";
import icon from '../../images/logo.svg';
import {Link} from "react-router-dom";
import {RoutePath} from "../../routes";
import {IUser} from "../../store/types";
import {connect} from "react-redux";
import {Dispatch} from "redux";
import {cleanActionCreator} from "../../store/reducer";
import './logo.css';

interface IProps {
  cleanStore: () => void;
}

const Logo: React.FC<IProps> = (props) => {
  return <Link className="logo" to={RoutePath.INDEX} onClick={() => props.cleanStore()}>
    <img className="logo__icon" src={icon} alt="logo" />
    <h1 className="logo__text">PlanPoker</h1>
  </Link>
  ;
}

const mapDispatchToProps = (dispatch: Dispatch) => {
  return {
    cleanStore: () => {
      dispatch(cleanActionCreator());
    }
  }
}

export default connect(null, mapDispatchToProps)(Logo);
