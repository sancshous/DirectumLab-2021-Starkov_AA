import * as React from "react";
import {RouteComponentProps} from "react-router";
import Header from "../header/header";
import Form from "./form/form";
import Footer from "../footer/footer";
import {RoutePath} from "../../routes";
import {createRoom} from "../../api/api";
import {IUser} from "../../store/types";
import {compose, Dispatch} from "redux";
import {updateUser} from "../../store/user/user-action-creators";
import {withRouter} from "react-router-dom";
import {connect} from "react-redux";

interface IProps extends RouteComponentProps{
  updateUser: (user: IUser) => void
}

class CreatePage extends React.Component<IProps, any>  {

  // eslint-disable-next-line react/sort-comp
  private readonly userNameRef: React.RefObject<HTMLInputElement>;
  private readonly roomNameRef: React.RefObject<HTMLInputElement>;

  constructor(props: IProps) {
    super(props);
    this.userNameRef = React.createRef();
    this.roomNameRef = React.createRef();
    this.handleSubmit = this.handleSubmit.bind(this);
  }

  componentDidMount() {
    this.userNameRef.current && this.userNameRef.current.focus();
  }

  handleSubmit = (evt: React.FormEvent) => {
    evt.preventDefault();
    const {current: userName } = this.userNameRef;
    const {current: roomName } = this.roomNameRef;
    if(userName && roomName) {
      const response = createRoom(userName.value, roomName.value);
      this.props.updateUser(response.user);
      this.props.history.push(`${RoutePath.ROOM}/${response.roomId}`);
    }
  }

  render() {
    return <div className={'body'}>
      <Header />
      <main className="main">
        <div className="container main__content">
          <Form
            userRef={this.userNameRef}
            roomRef={this.roomNameRef}
            onSubmit={this.handleSubmit}
            loginPage={'create'} />
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

export default compose<React.ComponentClass>(withRouter, connect(null, mapDispatchToProps))(CreatePage);
