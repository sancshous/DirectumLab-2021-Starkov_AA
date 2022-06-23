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
import {searchRoom} from "../../api/poker-api";

interface IMatchParams {
  roomId: string;
}

interface IProps extends RouteComponentProps<IMatchParams>{
  user: IUser | null,
  room: IRoom | null,
  cards: ICard[],
  updateRoom: (roomId: string) => Promise<any>,
  createDiscussion: (roomId: string, title: string) => Promise<any>,
  closeDiscussion: (discussionId: string, roomId: string) => Promise<any>,
  deleteDiscussion: (roomId: string, discussionId: string) => Promise<any>,
  searchUser: (userId: string, roomId: string) => Promise<IUser>,
  loadCards: () => Promise<ICard[]>,
  addVote: (cardId: string | null, userId: string | undefined, discussionId: string | undefined) => Promise<any>,
  updateDiscussions: (roomId: string) => Promise<IDiscussion[]>,
  getRoomInfo: (roomId: string) => Promise<any>
}

class RoomPageView extends React.Component<IProps, any> {

  constructor(props: IProps) {
    super(props);

    this.state = {
      timer: null
    }

    this.handleClickGO = this.handleClickGO.bind(this);
    this.handleClickFinish = this.handleClickFinish.bind(this);
    this.handleClickDeleteDiscus = this.handleClickDeleteDiscus.bind(this);
    this.handleVote = this.handleVote.bind(this);
  }

  public async componentDidMount() {
    if (this.props.room == null && this.props.user == null) {
      const room = await searchRoom(this.props.match.params.roomId);
      if (room == false || room == null) {
        this.props.history.push(`${RoutePath.INVITE}/${this.props.match.params.roomId}`);
        await this.props.updateRoom(this.props.match.params.roomId);
        await this.props.loadCards();
        return;
      }
      const userId = localStorage.getItem('userId');
      const user = userId != null ? await this.props.searchUser(userId, this.props.match.params.roomId) : null;
      if (user == null) {
        this.props.history.push(`${RoutePath.INVITE}/${this.props.match.params.roomId}`);
        return;
      }
    }

    this.timer = setInterval(this.props.updateRoom, 1000, this.props.match.params.roomId)
  }

  public async componentWillUnmount() {
    clearInterval(this.timer);
  }

  private timer: any = null;

  private updateRoom() {
    this.props.updateRoom(this.props.match.params.roomId);
  }

  private handleClickGO = async (title: string) => {
    await this.props.loadCards();
    await this.props.createDiscussion(this.props.match.params.roomId, title);
    this.updateRoom();
  }

  private handleClickFinish = async () => {
    const discus = this.getCurrentDiscussion();
    if(discus != null) {
      await this.props.closeDiscussion(discus.id, this.props.match.params.roomId);
      this.updateRoom();
    }
  }

  private handleClickDeleteDiscus = async (discussionId: string) => {
    await this.props.deleteDiscussion(this.props.match.params.roomId, discussionId);
    this.updateRoom();
  }

  private getCardIdByCardValue = (value: string): string | null => {
    if(this.props.cards != null) {
      const cardsObj = Object.entries(this.props.cards);
      const array: ICard[] = [];
      cardsObj.forEach(([key, value]) => {
        array.push(value);
      });

      const card = array.find((card) => card.value.toString() === value );
      if(card != null)
        return card.id;
    }
    return null;
  }

  private handleVote = async (value: string) => {
    const currentDiscussion = this.getCurrentDiscussion();
    if (currentDiscussion?.votes.length != null) {
      const vote = currentDiscussion?.votes.find((v) => v.userId === this.props.user?.id);
      if (vote != null) {
        for (let i = 0; i < currentDiscussion?.votes.length; i++) {
          if (currentDiscussion?.votes[i] === vote) {
            currentDiscussion?.votes.splice(i, 1);
            i--;
          }
        }
      }
    }

    await this.props.addVote(this.getCardIdByCardValue(value), this.props.user?.id, currentDiscussion?.id);
    this.updateRoom();
  }

  private getCurrentDiscussion() {
    if(this.props.room?.discussions != null && this.props.room.discussions.length > 0 ) {
      const currentDiscussion = (this.props.room.discussions)[this.props.room.discussions.length - 1];
      return currentDiscussion;
    }
    return null;
  }

  private getCurrentVote(userId: string | undefined): IVote | null {
    const currentDiscussion = this.getCurrentDiscussion();
    const currentVote = currentDiscussion?.votes.find((v) => v.userId === userId);
    if(currentVote != null)
      return currentVote;
    return null;
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

  public parseVotes(): [string, number][] | null {
    const discus = this.getCurrentDiscussion();
    if(discus != null) {
      const array: number[] = [];
      discus.votes.map((vote) => {
        array.push(vote.card.value)
      })
      const result = array.reduce(function(acc:Record<string, number>, el) {
        acc[el] = (acc[el] || 0) + 1;
        return acc;
      }, {});
      const cardsObj = Object.entries(result);
      return cardsObj;
    }
    return null;
  }

  public parseVoteValue(cardsObj: [string, number][] | null): string[] | null {
    if(cardsObj != null) {
      const labels: string[] = [];
      cardsObj.forEach(([key, value]) => {
        if(key === '0') {
          key = 'coffee'
          labels.push(key);
        }
        else if (key === '-10') {
          key = '?'
          labels.push(key);
        }
        else
          labels.push(key);
      });
      return labels;
    }
    return null;
  }

  public parseCountVoteValue(cardsObj: [string, number][] | null): number[] | null {
    if(cardsObj != null) {
      const numbers: number[] = [];
      cardsObj.forEach(([key, value]) => {
        numbers.push(value);
      });
      return numbers;
    }
    return null;
  }

  public renderPlaceHolder(): React.ReactNode {
    return <StoryPlaceHolder />
  }

  public renderDeck(room: IRoom): React.ReactNode {
    const isOwner = this.props.user?.id == this.props.room?.ownerId ? true : false;
    return <>
      <div className="content">
        <p className={'Story'}>{this.getCurrentDiscussion()?.title}</p>
        <CardGroup
          cards={this.parseCards()}
          vote={this.handleVote}
          selectedCard={this.getCurrentVote(this.props.user?.id)?.card.value.toString() || null} />
        {this.props.room?.discussions.find((d) => d.end != null) != undefined && <History isOwner={isOwner} onClick={this.handleClickDeleteDiscus} room={room} defaultState={undefined} />}
      </div>
    </>
  }

  public renderResult(): React.ReactNode {
    const discus = this.getCurrentDiscussion();
    let playersQuantity = 0;
    let average: number | null = 0;
    const isOwner = this.props.user?.id == this.props.room?.ownerId ? true : false;
    if(discus != null) {
      playersQuantity = discus.votes.length;
      average = discus.averageVote;
    }
    return <>
      <div className="content">
        <p className={'Story'}>{this.getCurrentDiscussion()?.title}</p>
        <VoteResultContainer valueLabels={this.parseVoteValue(this.parseVotes())} valueVotes={this.parseCountVoteValue(this.parseVotes())} playersQuantityVoted={playersQuantity} average={average} />
        {this.getCurrentDiscussion()?.end != null && <History isOwner={isOwner} onClick={this.handleClickDeleteDiscus} room={this.props.room} defaultState={undefined} />}
      </div>
    </>
  }

  public renderWorkArea(room: IRoom, discussion: IDiscussion | null) {
    if (discussion == null)
      return this.renderPlaceHolder();
    else if (discussion.end)
      return this.renderResult();
    else
      return this.renderDeck(room);
  }

  public renderContent(room: IRoom) : React.ReactNode {
    const currentDiscussion = this.getCurrentDiscussion();
    let btn = '';
    let status = '';
    let discussionClassName = '';
    const isOwner = this.props.user?.id == room.ownerId ? true : false;
    { currentDiscussion == null || currentDiscussion.end ? btn = 'go' : btn = 'finish'}
    if(currentDiscussion == null) {
      status = ''
      discussionClassName = 'story';
    }
    else if(currentDiscussion.end != null)
      status = 'result'
    else
      status = 'voted'
    const playersQuantityVoted = this.getCurrentDiscussion()?.votes.length;
    return (
      <>
        {this.renderWorkArea(room, currentDiscussion)}
        <Players
          input={btn}
          title={'Story voting'}
          className={discussionClassName}
          users={room.users}
          quantityVoted={playersQuantityVoted}
          discussion={currentDiscussion}
          isOwner={isOwner}
          status={status}
          onSubmitGo={this.handleClickGO}
          onSubmitFinish={this.handleClickFinish} >
        </Players>
      </>
    );
  }

  render() {
    const { room, user } = this.props;
    if (room == null || user == null) {
      return null;
    }
      return (
        <div className={'body'}>
          <Header />
          <main className="main">
            <div className={`container main__content ${room?.discussions != null && 'story'}`}>
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
