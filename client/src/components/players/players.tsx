import * as React from "react";
import Player from "./player/player";
import PlayersInput from "./players-input/players-input";
import Button from "../button/button";
import {IUser} from "../../store/types";
import './players.css';


interface IProps {
  input: string,
  title: string,
  className?: string,
  users: Array<IUser>,
  onSubmitInput: () => void,
  onSubmitGoFinish: () => void
}

const Players: React.FC<IProps> = (props) => {
  function RenderInputButton() {
    switch (props.input) {
      case 'go':
        return <div className="players__placeholder">
          <input className="players__input players__storyname" type="text" placeholder="I" required={true} />
          <Button onClick={props.onSubmitGoFinish} className={'players__btn-next'} title={'Go'} />
        </div>
      case 'finish':
        return <Button onClick={props.onSubmitGoFinish} className={'players__btn'} title={'Finish Voiting'} />
    }
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
            <Player key={user.id} name={user.name} />
          ))
        }
      </ul>
      <PlayersInput onSubmit={props.onSubmitInput} />
    </div>
  </div>
    ;
}

export default Players;
