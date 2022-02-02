import * as React from "react";
import Card from "./card/card";
import "./card-group.css";

interface ICards {
  card: string
}

interface IState {
  clicked: number | null
}

const numbers: ICards[] = [
  {card: '0'},
  {card: '0.5'},
  {card: '1'},
  {card: '2'},
  {card: '3'},
  {card: '5'},
  {card: '8'},
  {card: '13'},
  {card: '20'},
  {card: '40'},
  {card: '100'},
  {card: '?'},
  {card: '-100'},
]

class CardGroup extends React.Component<ICards, IState> {
  constructor(props: ICards) {
    super(props);
    this.state = {
      clicked: null
    }
  }

  handleClick(id: number) {
    this.setState({clicked: id});
  };

  render() {
    return <ul className="card_group">
      {
        numbers.map((num, index) => (
          <Card className={this.state.clicked === index && "card_selected"} onClick={() => this.handleClick(index)} key={num.card} value={num.card} />
        ))
      }
    </ul>
      ;
  }
}

export default CardGroup;
