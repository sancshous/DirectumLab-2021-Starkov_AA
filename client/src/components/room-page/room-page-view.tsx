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
import {IRoom, IDiscussion, IUser, ICard} from "../../store/types";

interface IMatchParams {
  roomId: string;
}

interface IProps extends RouteComponentProps<IMatchParams>{
  user: IUser,
  room: IRoom,
  cards: ICard[],
  //discussions: IDiscussion[],
  updateRoom: (roomId: string) => Promise<any>,
  createDiscussion: (roomId: string) => Promise<any>,
  updateDiscussions: (roomId: string) => Promise<IDiscussion[]>,
  getRoomInfo: (roomId: string) => Promise<any>
}

class RoomPageView extends React.Component<IProps, any> {

  constructor(props: IProps) {
    super(props);

    /*this.state = {
      timer: null
    }*/

    this.handleClickInput = this.handleClickInput.bind(this);
    this.handleClickGO = this.handleClickGO.bind(this);
    this.handleClickFinish = this.handleClickFinish.bind(this);
    this.handleVote = this.handleVote.bind(this);
  }

  public componentDidMount() {
    if(this.props.room == null)
      this.updateRoom();

   /* this.setState({
      timer: setInterval(this.props.getRoomInfo, 1000, this.props.match.params.roomId)
    })*/
  }

  private updateRoom() {
    this.props.updateRoom(this.props.match.params.roomId);
  }

  private handleClickGO = () => {
    this.props.createDiscussion(this.props.match.params.roomId);
    this.updateRoom();
  }

  private handleClickFinish = () => {
    const {room} = this.props;
    if(room != null) {
      this.updateRoom();
    }
  }

  private handleVote = (value: string) => {
    const {room} = this.props;
    if(room != null) {
      this.updateRoom();
    }
  }

  private readonly handleClickInput = () => {
    this.props.history.push(`${RoutePath.INVITE}/${this.props.match.params.roomId}`);
  }

  private getCurrentDiscussion() {
    if(this.props.room.discussions != null && this.props.room.discussions.length > 0 ) {
      const currentDiscussion = (this.props.room.discussions)[this.props.room.discussions.length - 1];
      return currentDiscussion;
    }
    return null;
  }

  public renderPlaceHolder(): React.ReactNode {
    return <StoryPlaceHolder />
  }

  public renderDeck(room: IRoom): React.ReactNode {
    return <>
      <div className="content">
        <p className={'Story'}>{this.getCurrentDiscussion()?.name}</p>
        <CardGroup
          cards={this.props.room.cards}
          vote={this.handleVote}
          selectedCard={this.getCurrentDiscussion()?.votes[this.props.user?.id || ''] || null} />
        <History defaultState={false} />
      </div>
    </>
  }

  public renderResult(): React.ReactNode {
    return <>
      <div className="content">
        <p className={'Story'}>{this.getCurrentDiscussion()?.name}</p>
        <VoteResultContainer />
        <History defaultState={false} />
      </div>
    </>
  }

  public renderWorkArea(room: IRoom, discussion: IDiscussion | null) {
    if (discussion == null)
      return this.renderPlaceHolder();
    else if (discussion.average)
      return this.renderResult();
    else
      return this.renderDeck(room);
  }

  public renderContent(room: IRoom) : React.ReactNode {
    const currentStory = this.getCurrentDiscussion();
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
          <div className={`container main__content ${this.props.room.discussions != null && 'story'}`}>
            {/*<h2 className={'story__name'}>{this.getCurrentDiscussion()?.name}</h2>*/}
            {room ? this.renderContent(room) : null}
          </div>
        </main>

        <Footer />
      </div>
    );
  }
}

export default RoomPageView
