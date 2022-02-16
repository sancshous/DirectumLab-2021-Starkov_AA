import * as React from "react";
import Player from "./player/player";
import PlayersInput from "./players-input/players-input";
import Button from "../button/button";
import {IDiscussion, IUser, IVote} from "../../store/types";
import './players.css';


interface IProps {
  input: string,
  title: string,
  className?: string,
  users: Array<IUser>,
  discussion: IDiscussion | null,
  status: string,
  onSubmitInput: () => void,
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
          <input ref={inputRef} className="players__input players__storyname" type="text" placeholder="I" required={true} />
          <Button onClick={handleSubmit} className={'players__btn-next'} title={'Go'} />
        </div>
      case 'finish':
        return <>
          <Button onClick={props.onSubmitFinish} className={'players__btn'} title={'Finish Voiting'} />
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
      <h2 className="players__title">Players(1/{props.users.length})</h2>
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
      <PlayersInput onSubmit={props.onSubmitInput} />
    </div>
  </div>
    ;
}

export default Players;
