import * as React from "react";
import Card from "./card/card";
import "./card-group.css";

interface IState {
  clicked: number | null
}

interface IProps {
  cards: string[];
}

class CardGroup extends React.Component<IProps, IState> {
  constructor(props: IProps) {
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
        this.props.cards.map((num, index) => (
          <Card className={this.state.clicked === index && "card_selected"} onClick={() => this.handleClick(index)} key={num} value={num} />
        ))
      }
    </ul>
      ;
  }
}

export default CardGroup;
