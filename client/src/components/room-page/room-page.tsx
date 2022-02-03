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
import {IRoom, IStory, IUser} from "../../store/types";
import {createStory, loadRoom, vote} from "../../api/api";

interface IState {
  forceUpdate: boolean
}

interface IMatchParams {
  roomId: string;
}

interface IProps extends RouteComponentProps<IMatchParams> {
  user: IUser | null,
  room: IRoom | null
}

class RoomPage extends React.Component<IProps, IState> {

  constructor(props: IProps) {
    super(props);
    this.state = {
      forceUpdate: true
    };
    this.handleClick = this.handleClick.bind(this);
    this.handleCreateClick = this.handleCreateClick.bind(this);
    this.handleVote = this.handleVote.bind(this);
  }

  public componentDidMount() {
    if(this.props.room == null) {
      const room = loadRoom(this.props.match.params.roomId);
      this.setState({
        forceUpdate: true
      });
    }
  }

  private readonly handleClick = () => {
    this.props.history.push(`${RoutePath.INVITE}/${this.props.match.params.roomId}`);
  }

  private readonly handleCreateClick = () => {
    const story = createStory(this.props.match.params.roomId, 'TestStory');
    this.setState({
      forceUpdate: true
    });
  }

  private readonly handleVote = (value: string) => {
    const {room} = this.props;
    if(room != null) {
      vote(room.id, room.stories[room.stories.length - 1].id, value);
      this.setState({
        forceUpdate: true
      });
    }
  }

  private getCurrentStory(): IStory | null {
    return this.props.room?.stories[this.props.room?.stories.length - 1] || null;
  }

  public renderPlaceHolder(): React.ReactNode {
    return <StoryPlaceHolder />
  }

  public renderDeck(room: IRoom): React.ReactNode {
    return (
      <CardGroup values={room.cards} vote={this.handleVote} />
    );
  }

  public renderWorkArea(room: IRoom, story: IStory | null) {
    if(story == null)
      return this.renderPlaceHolder();
    else if(story.average)
      return <div>Result</div>;
    else
      return this.renderDeck(room);
  }

  /*public renderPlaceHolder(): React.ReactNode {
    return <>
      <StoryPlaceHolder />
      <Players
        title={'Новое голосование'}
        onSubmitGoFinish={this.handleClickGO}
        onSubmitInput={this.handleClickInput}
        className={'story'}
        input={'go'} />
    </>
  }*/

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

  /*public renderResult(): React.ReactNode {
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
  }*/

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
