import * as React from "react";
import {RouteComponentProps} from "react-router";
import Header from "../header/header";
import Footer from "../footer/footer";
import StoryPlaceHolder from "./new-story/story-placeholder/story-placeholder";
import Players from "../players/players";
import CardGroup from "./voting-page/card-group/card-group";
import History from "../history/history";
import VoteResultContainer from "./voted-page/vote-result-container/vote-result-container";
import {RoutePath} from "../../routes";
import {IRoom, IRootState, IUser} from "../../store/types";
import {loadRoom} from "../../api/api";
import {room} from "../../store/mockStore";

export enum RoomState {
  NEW = 'new',
  VOTING = 'voting',
  VOTED = 'voted'
}

interface IState {
  roomState: RoomState
}

interface IMatchParams {
  roomId: string;
}

interface IProps extends RouteComponentProps<IMatchParams>{
  user: IUser,
  room: IRoom,
  updateRoom: (room: IRoom) => void
}

class RoomPageView extends React.Component<IProps, IState> {

  constructor(props: IProps) {
    super(props);
    this.state = {
      roomState: RoomState.NEW
    };
    this.handleClickInput = this.handleClickInput.bind(this);
    this.handleClickGO = this.handleClickGO.bind(this);
    this.handleClickFinish = this.handleClickFinish.bind(this);
  }

  public componentDidMount() {
    if(this.props.room == null) {
      const room = loadRoom(this.props.match.params.roomId);
      if (room)
        this.props.updateRoom(room);
    }
  }

  private readonly handleClickInput = () => {
    this.props.history.push(`${RoutePath.INVITE}/${this.props.match.params.roomId}`);
  }

  private readonly handleClickGO = () => {
    // const storyId = Math.round(Math.random() * (100 - 1) + 1);
    this.setState({
      roomState: RoomState.VOTING
    });
  }

  private readonly handleClickFinish = () => {
    this.setState({
      roomState: RoomState.VOTED
    });
  }

  public renderPlaceHolder(): React.ReactNode {
    return <>
      <StoryPlaceHolder />
      <Players
        users={room.users}
        title={'Новое голосование'}
        onSubmitGoFinish={this.handleClickGO}
        onSubmitInput={this.handleClickInput}
        className={'story'}
        input={'go'} />
    </>
  }

  public renderDeck(): React.ReactNode {
    return <>
      <div className="content">
        <p className="Story">Story</p>
        <CardGroup cards={room.cards} />
        <History defaultState={false} />
      </div>
      <Players
        users={room.users}
        title={'Голосование началось'}
        onSubmitGoFinish={this.handleClickFinish}
        onSubmitInput={this.handleClickInput}
        className={''}
        input={'finish'} />
    </>
  }

  public renderResult(): React.ReactNode {
    return <>
      <div className="content">
        <p className="Story">Story</p>
        <VoteResultContainer />
        <History defaultState={false} />
      </div>
      <Players
        users={room.users}
        title={'Голосование завершилось'}
        onSubmitGoFinish={this.handleClickGO}
        onSubmitInput={this.handleClickInput}
        className={''}
        input={'go'} />
    </>
  }

  render() {
    const {roomState} = this.state;
    let template = this.renderPlaceHolder();
    let storyClass = '';

    switch (roomState) {
      case RoomState.VOTING:
        template = this.renderDeck();
        storyClass = 'story';
        break;
      case RoomState.VOTED:
        template = this.renderResult();
        storyClass = 'story';
        break;
    }

    return <div className={'body'}>
      <Header />
      <main className="main">
        <div className={`container main__content ${storyClass}`}>
          {template}
        </div>
      </main>

      <Footer />
    </div>
      ;
  }
}

export default RoomPageView
