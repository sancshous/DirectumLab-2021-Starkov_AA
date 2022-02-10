import * as React from "react";
import "./card.css";

const coffeeIcon = <svg width="43" height="44" viewBox="0 0 43 44" fill="none" xmlns="http://www.w3.org/2000/svg">
  <path id="coffe" fillRule="evenodd" clipRule="evenodd"
    d="M35.5936 5.5H7.74343V23.8333C7.74343 27.885 10.8592 31.1667 14.706 31.1667H25.1498C28.9966 31.1667 32.1123 27.885 32.1123 23.8333V18.3333H35.5936C37.5257 18.3333 39.0749 16.7017 39.0749 14.6667V9.16667C39.0749 7.13167 37.5257 5.5 35.5936 5.5ZM35.5936 14.6667H32.1123V9.16667H35.5936V14.6667ZM35.5936 38.5H4.26216V34.8333H35.5936V38.5Z"
    fill="#131B23" />
</svg>

interface IProps {
  value: string,
  className?: string,
  onClick: (value: string) => void
}

const Card: React.FC<IProps> = (props) => {
  function renderValueCard() {
    switch (props.value) {
      case '-10':
        return '?';
      case '-100':
        return coffeeIcon
      default:
        return props.value
    }
  }
  return <li>
    <button
      className={`card ${props.className || ''}`}
      onClick={() => props.onClick(props.value)}>
      {renderValueCard()}
    </button>
  </li>;
}

export default Card;
