import * as React from "react";
import {Link} from "react-router-dom";
import {RoutePath} from "../../routes";
import {IUser} from "../../store/types";
import {Dispatch} from "redux";
import {cleanActionCreator} from "../../store/reducer";
import {connect} from "react-redux";
import './footer.css';

interface IProps {
  updateUser: (user?: IUser) => void;
}

const Footer: React.FC<IProps> = (props) => {
  return <footer className="footer">
    <p>Copyright 2021 <Link className="footer__text" to={RoutePath.INDEX} onClick={() => props.updateUser()}>PlanPoker</Link></p>
  </footer>
    ;
}

const mapDispatchToProps = (dispatch: Dispatch) => {
  return {
    updateUser: (user?: IUser) => {
      dispatch(cleanActionCreator());
    }
  }
}

export default connect(null, mapDispatchToProps)(Footer);
