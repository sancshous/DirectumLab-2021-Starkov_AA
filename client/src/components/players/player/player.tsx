import * as React from "react";
import user from '../../../images/user.svg';
import voted from '../../../images/voted.svg';
import './player.css';

interface IProps {
  name: string,
  status?: string | null
}


const Player: React.FC<IProps> = (props) => {

  function RenderPlayerStatus() {
    switch (props.status) {
      case 'voted':
        return <img className="player__voted" src={voted} alt="voted" />
      case 'voting':
        return <span className="player__voting">3</span>
      default:
        return <span>{''}</span>
    }
  }

  return <li className="player">
    <div className="player__container">
      <img className="player__icon" src={user} alt="player" />
      <span className="player__text">{props.name}</span>
    </div>
    {
      RenderPlayerStatus()
    }
  </li>
    ;
}

export default Player;
