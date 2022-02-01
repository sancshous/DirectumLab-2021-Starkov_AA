import * as React from "react";
import {withRouter} from "react-router-dom";
import {RouteComponentProps} from "react-router";
import Header from "../header/header";
import Footer from "../footer/footer";
import StoryPlaceHolder from "./new-story/story-placeholder/story-placeholder";
import Players from "../players/players";
import CardGroup from "./voting-page/card-group/card-group";
import History from "../history/history";
import VoteResultContainer from "./voted-page/vote-result-container/vote-result-container";
import {RoutePath} from "../../routes";

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

class RoomPage extends React.Component<RouteComponentProps<IMatchParams>, IState> {

  constructor(props: RouteComponentProps<IMatchParams>) {
    super(props);
    this.state = {
      roomState: RoomState.NEW
    };
    this.handleClickInput = this.handleClickInput.bind(this);
    this.handleClickGO = this.handleClickGO.bind(this);
    this.handleClickFinish = this.handleClickFinish.bind(this);
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
        <CardGroup card={''} />
        <History defaultState={false} />
      </div>
      <Players
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
        storyClass = ' story';
        break;
      case RoomState.VOTED:
        template = this.renderResult();
        storyClass = ' story';
        break;
    }

    return <div className={'body'}>
      <Header user={{name: 'Dima'}} />
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

export default withRouter(RoomPage);
