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
import {IRoom, IDiscussion, IUser, ICard, IVote} from "../../store/types";
import card from "./voting-page/card-group/card/card";

interface IMatchParams {
  roomId: string;
}

interface IProps extends RouteComponentProps<IMatchParams>{
  user: IUser,
  room: IRoom,
  cards: ICard[],
  updateRoom: (roomId: string) => Promise<any>,
  createDiscussion: (roomId: string) => Promise<any>,
  loadCards: () => Promise<ICard[]>,
  addVote: (cardId: string | undefined, userId: string, discussionId: string | undefined) => Promise<any>,
  updateDiscussions: (roomId: string) => Promise<IDiscussion[]>,
  getRoomInfo: (roomId: string) => Promise<any>
}

class RoomPageView extends React.Component<IProps, any> {

  constructor(props: IProps) {
    super(props);

    this.state = {
      timer: null
    }

    this.handleClickInput = this.handleClickInput.bind(this);
    this.handleClickGO = this.handleClickGO.bind(this);
    this.handleClickFinish = this.handleClickFinish.bind(this);
    this.handleVote = this.handleVote.bind(this);
  }

  public componentDidMount() {
    if(this.props.room == null) {
      this.updateRoom();
    }

    this.setState({
      timer: setInterval(this.props.updateRoom, 2000, this.props.match.params.roomId)
    })
  }

  private updateRoom() {
    this.props.updateRoom(this.props.match.params.roomId);
  }

  private handleClickGO = () => {
    this.props.loadCards();
    this.props.createDiscussion(this.props.match.params.roomId);
    this.updateRoom();
  }

  private handleClickFinish = () => {
    const {room} = this.props;
    if(room != null) {
      this.updateRoom();
    }
  }

  private handleVote = () => {
    const {id} = this.props.user;
    this.props.addVote(this.getCurrentVote(id)?.card.id, id, this.getCurrentDiscussion()?.id);
    this.updateRoom();
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

  private getCurrentVote(userId: string): IVote | null {
    const currentDiscussion = this.getCurrentDiscussion();
    const currentVote = currentDiscussion?.votes.find((v) => v.userId === userId);
    if(currentVote != null)
      return currentVote;
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
          cards={this.parseCards()}
          vote={this.handleVote}
          selectedCard={this.getCurrentVote(this.props.user.id)?.card.value.toString() || null} />
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

  public parseCards(): string[] | null {
    if(this.props.cards != null) {
      const cardsObj = Object.entries(this.props.cards);
      const array: ICard[] = [];
      cardsObj.forEach(([key, value]) => {
        array.push(value);
      });
      return array.map((card) => card.value.toString());
    }
    return null;
  }

  public renderContent(room: IRoom) : React.ReactNode {
    const currentDiscussion = this.getCurrentDiscussion();
    let btn = '';
    let status = '';
    let storyClassName = '';
    { currentDiscussion == null || currentDiscussion.average ? btn = 'go' : btn = 'finish'}
    if(currentDiscussion == null) {
      status = ''
      storyClassName = 'story';
    }
    else if(currentDiscussion.average != null)
      status = 'result'
    else
      status = 'voted'
    return (
      <>
        {this.renderWorkArea(room, currentDiscussion)}
        <Players
          input={btn}
          title={'Story voting'}
          className={storyClassName}
          users={room.users}
          discussion={currentDiscussion}
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
