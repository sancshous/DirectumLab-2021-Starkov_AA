import * as React from "react";
import Card from "./card/card";
import "./card-group.css";

interface IProps {
  cards: string[],
  selectedCard?: string | null,
  vote: (value: string) => void
}

const CardGroup: React.FC<IProps> = (props) => {
  return <ul className="card_group">
    {
      props.cards.map((card) => (
        <Card className={`${props.selectedCard === card && 'card_selected'}`} key={card} value={card} onClick={() => props.vote(card)} />
      ))
    }
  </ul>;
}

export default CardGroup;
