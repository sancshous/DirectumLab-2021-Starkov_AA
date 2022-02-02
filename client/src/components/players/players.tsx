import * as React from "react";
import Player from "./player/player";
import PlayersInput from "./players-input/players-input";
import Button from "../button/button";
import './players.css';

interface IProps {
  input: string,
  title: string,
  className?: string,
  onSubmitInput: () => void,
  onSubmitGoFinish: () => void
}

interface IUsers {
  name: string,
  status?: string | null
}

const users: IUsers[] = [
  {name: 'Дмитрий', status: 'voting'},
  {name: 'Павел', status: null},
  {name: 'Мария', status: 'voted'},
  {name: 'Сергей', status: 'voting'},
  {name: 'Александра', status: null},
  {name: 'Оля', status: 'voted'},
  {name: 'Анастасия', status: 'voted'}
]

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
      <h2 className="players__title">Players(2/{users.length})</h2>
      <ul className="players__group">
        {
          users.map((user) => (
            <Player key={user.name} name={user.name} status={user.status} />
          ))
        }
      </ul>
      <PlayersInput onSubmit={props.onSubmitInput} />
    </div>
  </div>
    ;
}

export default Players;
