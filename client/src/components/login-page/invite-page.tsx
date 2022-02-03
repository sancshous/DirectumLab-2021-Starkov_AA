import * as React from "react";
import Header from "../header/header";
import Footer from "../footer/footer";
import {withRouter} from "react-router-dom";
import {RouteComponentProps} from "react-router";
import Form from "./form/form";
import {RoutePath} from "../../routes";
import {createRoom, join} from "../../api/api";
import {match} from "assert";

interface IMatchParams {
  roomId: string;
}

class InvitePage extends React.Component<RouteComponentProps<IMatchParams>, any> {

  // eslint-disable-next-line react/sort-comp
  private readonly userNameRef: React.RefObject<HTMLInputElement>;

  constructor(props: RouteComponentProps<IMatchParams>) {
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
      const user = join(match.params.roomId, userName.value);
      history.push(`${RoutePath.ROOM}/${match.params.roomId}`);
    }
  }

  render() {
    return <div className={'body'}>
      <Header user={null} />
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

export default withRouter(InvitePage);
