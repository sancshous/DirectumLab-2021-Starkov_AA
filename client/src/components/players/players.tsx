import * as React from "react";
import Player from "./player/player";
import PlayersInput from "./players-input/players-input";
import {IDiscussion, IUser} from "../../store/types";
import Button from "../button/button";
import './players.css';


interface IProps {
  input: string,
  title: string,
  className?: string,
  users: Array<IUser>,
  quantityVoted: number | undefined,
  discussion: IDiscussion | null,
  status: string,
  isOwner: boolean,
  onSubmitGo: (value: string) => void,
  onSubmitFinish: () => void,
}

const Players: React.FC<IProps> = (props) => {

  const inputRef = React.useRef<HTMLInputElement>(null);
  const handleSubmit = () => {
    if(inputRef.current) {
      props.onSubmitGo(inputRef.current.value);
    }
  }

  function RenderInputButton() {
    switch (props.input) {
      case 'go':
        return <div className="players__placeholder">
          {props.isOwner &&
            <>
              <input ref={inputRef} className="players__input players__storyname" type="text" placeholder="" required={true} />
              <Button onClick={handleSubmit} className={'players__btn-next'} title={'Go'} />
            </>
          }
        </div>
      case 'finish':
        return <>
          {props.isOwner && <Button onClick={props.onSubmitFinish} className={'players__btn'} title={'Finish Voiting'} />}
        </>
    }
  }

  function getVoteValue(userId: string): string | null {
    const vote = props.discussion?.votes.find((v) => (v.userId === userId));
    if(vote != null) {
      return vote.card.value.toString();
    }
    return null;
  }

  return <div className={`players ${props.className || ''}`}>
    <p className="players__header">{props.title}</p>
    <div className="players__body">
      {
        RenderInputButton()
      }
      <h2 className="players__title">Players({props.quantityVoted == null ? 0 : props.quantityVoted}/{props.users.length})</h2>
      <ul className="players__group">
        {
          props.users.map((user) => (
            <Player
              key={user.id}
              name={user.name}
              status={props.status}
              voteValue={getVoteValue(user.id)} />
          ))
        }
      </ul>
      <PlayersInput />
    </div>
  </div>
    ;
}

export default Players;
