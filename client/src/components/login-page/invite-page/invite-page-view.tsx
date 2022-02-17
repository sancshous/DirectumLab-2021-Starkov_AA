import * as React from "react";
import Header from "../../header/header";
import Footer from "../../footer/footer";
import {RouteComponentProps} from "react-router";
import Form from "../form/form";
import {RoutePath} from "../../../routes";
import {IRoom} from "../../../store/types";

interface IMatchParams {
  roomId: string;
}

interface IProps extends RouteComponentProps<IMatchParams>{
  inviteUser: (userName: string, roomId: string) => Promise<IRoom>;
}

class InvitePageView extends React.Component<IProps> {
  constructor(props: IProps) {
    super(props);
    this.userNameRef = React.createRef();
    this.handleSubmit = this.handleSubmit.bind(this);
  }

  private readonly userNameRef: React.RefObject<HTMLInputElement>;

  public async handleSubmit(evt: React.FormEvent) {
    evt.preventDefault();
    const { current: userName } = this.userNameRef;
    if (userName) {
      await this.props.inviteUser(userName.value, this.props.match.params.roomId);
      this.props.history.push(`${RoutePath.ROOM}/${this.props.match.params.roomId}`);
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

export default InvitePageView;
