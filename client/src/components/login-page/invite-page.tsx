import * as React from "react";
import Header from "../header/header";
import Footer from "../footer/footer";
import {RouteComponentProps} from "react-router";
import Form from "./form/form";
import {RoutePath} from "../../routes";
import {createRoom, join} from "../../api/api";
import {IUser} from "../../store/types";
import {compose, Dispatch} from "redux";
import {updateUser} from "../../store/user/user-action-creators";
import {withRouter} from "react-router-dom";
import {connect} from "react-redux";

interface IMatchParams {
  roomId: string;
}

interface IProps extends RouteComponentProps<IMatchParams>{
  updateUser: (user: IUser) => void
}

class InvitePage extends React.Component<IProps, any> {

  // eslint-disable-next-line react/sort-comp
  private readonly userNameRef: React.RefObject<HTMLInputElement>;

  constructor(props: IProps) {
    super(props);
    this.userNameRef = React.createRef();
    this.handleSubmit = this.handleSubmit.bind(this);
  }

  componentDidMount() {
    this.userNameRef.current && this.userNameRef.current.focus();
  }

  handleSubmit = (evt: React.FormEvent) => {
    evt.preventDefault();
    const {current: userName } = this.userNameRef;
    const {match, history } = this.props;
    if(userName) {
      const response = join(match.params.roomId, userName.value);
      this.props.updateUser(response);
      history.push(`${RoutePath.ROOM}/${match.params.roomId}`);
    }
  }

  render() {
    return <div className={'body'}>
      <Header />
      <main className="main">
        <div className="container main__content">
          <Form
            userRef={this.userNameRef}
            onSubmit={this.handleSubmit}
            loginPage={'invite'} />
        </div>
      </main>

      <Footer />
    </div>
      ;
  }
}
const mapDispatchToProps = (dispatch: Dispatch) => {
  return {
    updateUser: (user: IUser) => {
      dispatch(updateUser(user));
    }
  }
}

export default compose<React.ComponentClass>(withRouter, connect(null, mapDispatchToProps))(InvitePage);
