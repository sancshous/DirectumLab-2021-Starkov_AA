import * as React from "react";
import {RouteComponentProps} from "react-router";
import Header from "../../header/header";
import Form from "../form/form";
import Footer from "../../footer/footer";
import {RoutePath} from "../../../routes";

interface IProps extends RouteComponentProps{
  createRoom: (userName: string, roomName: string) => Promise<any>
}

class CreatePageView extends React.Component<IProps, any>  {
  constructor(props: IProps) {
    super(props);
    this.userNameRef = React.createRef();
    this.roomNameRef = React.createRef();
    this.handleSubmit = this.handleSubmit.bind(this);
  }

  componentDidMount() {
    this.userNameRef.current && this.userNameRef.current.focus();
  }

  private readonly userNameRef: React.RefObject<HTMLInputElement>;
  private readonly roomNameRef: React.RefObject<HTMLInputElement>;

  public async handleSubmit(evt: React.FormEvent) {
    evt.preventDefault();
    const {current: userName } = this.userNameRef;
    const {current: roomName } = this.roomNameRef;
    if(userName && roomName) {
      const roomId = await this.props.createRoom(userName.value, roomName.value);
      this.props.history.push(`${RoutePath.ROOM}/${roomId}`);
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

export default CreatePageView;
