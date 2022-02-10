import * as React from "react";
import user from '../../../images/user.svg';
import voted from '../../../images/voted.svg';
import './player.css';

interface IProps {
  name: string,
  voteValue?: string | null,
  status: string | null
}

const coffeeIcon = <svg width="22" height="23" viewBox="0 0 43 44" fill="none" xmlns="http://www.w3.org/2000/svg">
  <path id="coffe" fillRule="evenodd" clipRule="evenodd"
    d="M35.5936 5.5H7.74343V23.8333C7.74343 27.885 10.8592 31.1667 14.706 31.1667H25.1498C28.9966 31.1667 32.1123 27.885 32.1123 23.8333V18.3333H35.5936C37.5257 18.3333 39.0749 16.7017 39.0749 14.6667V9.16667C39.0749 7.13167 37.5257 5.5 35.5936 5.5ZM35.5936 14.6667H32.1123V9.16667H35.5936V14.6667ZM35.5936 38.5H4.26216V34.8333H35.5936V38.5Z"
    fill="#131B23" />
</svg>


const Player: React.FC<IProps> = (props) => {

  function renderValueCard() {
    switch (props.voteValue) {
      case '-10':
        return '?';
      case '-100':
        return coffeeIcon
      default:
        return props.voteValue
    }
  }
  function RenderPlayerStatus() {
    switch (props.status) {
      case 'voted':
        return  (props.voteValue && <img className="player__voted" src={voted} alt="voted" /> );
      case 'result':
        return <span className="player__voting">{renderValueCard()}</span>
      default:
        return <span>{''}</span>
    }
  }

  return <li className="player">
    <div className="player__container">
      <img className="player__icon" src={user} alt="player" />
      <span className="player__text">{props.name}</span>
    </div>
    {RenderPlayerStatus()}
  </li>
    ;
}

export default Player;
