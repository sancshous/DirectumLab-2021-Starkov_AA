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
import {IRoom, IStory, IUser} from "../../store/types";
import {addStoryIntoHistory, calcAverage, createStory, loadRoom, vote} from "../../api/api";

interface IMatchParams {
  roomId: string;
}

interface IProps extends RouteComponentProps<IMatchParams>{
  user: IUser,
  room: IRoom,
  updateRoom: (room: IRoom) => void,
  addIntoHistory: (story: IStory[]) => void
}

class RoomPageView extends React.Component<IProps, any> {

  constructor(props: IProps) {
    super(props);
    this.handleClickInput = this.handleClickInput.bind(this);
    this.handleClickGO = this.handleClickGO.bind(this);
    this.handleClickFinish = this.handleClickFinish.bind(this);
    this.handleVote = this.handleVote.bind(this);
  }

  public componentDidMount() {
    if(this.props.room == null) {
      const room = loadRoom(this.props.match.params.roomId);
      this.updateRoom(room)
    }
  }

  private updateRoom(room: IRoom | null) {
    if(room)
      this.props.updateRoom(room);
  }

  private handleClickGO = () => {
    const room = createStory(this.props.match.params.roomId, 'Bingo');
    this.updateRoom(room);
  }

  private handleClickFinish = () => {
    const {room} = this.props;
    if(room != null) {
      const updatedRoom = calcAverage(room.id, room.stories[room.stories.length - 1].id);
      this.updateRoom(updatedRoom);
      const story = addStoryIntoHistory(room.id, this.getCurrentStory());
      this.props.addIntoHistory(story);
    }
  }

  private handleVote = (value: string) => {
    const {room} = this.props;
    if(room != null) {
      const updatedRoom = vote(room.id, room.stories[room.stories.length - 1].id, value);
      this.updateRoom(updatedRoom);
    }
  }

  private readonly handleClickInput = () => {
    this.props.history.push(`${RoutePath.INVITE}/${this.props.match.params.roomId}`);
  }

  private getCurrentStory(): IStory | null {
    return this.props.room?.stories[this.props.room?.stories.length - 1] || null;
  }

  public renderPlaceHolder(): React.ReactNode {
    return <StoryPlaceHolder />
  }

  public renderDeck(room: IRoom): React.ReactNode {
    return <>
      <div className="content">
        <p className={'Story'}>{this.getCurrentStory()?.name}</p>
        <CardGroup
          cards={room.cards}
          vote={this.handleVote}
          selectedCard={this.getCurrentStory()?.votes[this.props.user?.id || ''] || null} />
        <History defaultState={false} />
      </div>
    </>
  }

  public renderResult(): React.ReactNode {
    return <>
      <div className="content">
        <p className={'Story'}>{this.getCurrentStory()?.name}</p>
        <VoteResultContainer />
        <History defaultState={false} />
      </div>
    </>
  }

  public renderWorkArea(room: IRoom, story: IStory | null) {
    if (story == null)
      return this.renderPlaceHolder();
    else if (story.average)
      return this.renderResult();
    else
      return this.renderDeck(room);
  }

  public renderContent(room: IRoom) : React.ReactNode {
    const currentStory = this.getCurrentStory();
    let btn = '';
    let status = '';
    let storyClassName = '';
    { currentStory == null || currentStory.average ? btn = 'go' : btn = 'finish'}
    if(currentStory == null) {
      status = ''
      storyClassName = 'story';
    }
    else if(currentStory.average != null)
      status = 'result'
    else
      status = 'voted'
    return (
      <>
        {this.renderWorkArea(room, currentStory)}
        <Players
          input={btn}
          title={'Story voting'}
          className={storyClassName}
          users={room.users}
          story={currentStory}
          status={status}
          onSubmitInput={this.handleClickInput}
          onSubmitGo={this.handleClickGO}
          onSubmitFinish={this.handleClickFinish} >
        </Players>
      </>
    );
  }

  render() {
    const {room} = this.props;
    return (
      <div className={'body'}>
        <Header />
        <main className="main">
          <div className={`container main__content ${room?.stories != null && 'story'}`}>
            {/*<h2 className={'story__name'}>{this.getCurrentStory()?.name}</h2>*/}
            {room ? this.renderContent(room) : null}
          </div>
        </main>

        <Footer />
      </div>
    );
  }
}

export default RoomPageView
