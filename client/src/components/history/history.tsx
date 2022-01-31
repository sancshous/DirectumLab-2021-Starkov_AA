import * as React from "react";
import HistoryHeader from "./history-header/history-header";
import Story from "./story/story";
import "./history.css";
import Modal from "../modal/modal";

interface IStories {
  id: number,
  title: string,
  value: string
}

const stories: IStories[] = [
  { id: 1, title: 'Планирование', value: '15'},
  { id: 2, title: 'Подведение итогов', value: '22'},
  { id: 3, title: 'Корпоратив', value: '6'},
  { id: 4, title: 'Подведение итогов', value: '22'},
  { id: 5, title: 'Подведение итогов', value: '22'}
]

interface IProps {
  defaultState: boolean
}

interface IState {
  showModal: boolean
}

class History extends React.Component<IProps, IState> {

  constructor(props: IProps) {
    super(props);
    this.state = {
      showModal: props.defaultState
    }
  }

  public handleClick() {
    this.setState({
      showModal: true
    });
  }

  render() {
    return <div className="history">
      <HistoryHeader mark={stories.length} />
      <table className="history__body">
        {
          stories.map((story) => (
            <Story onClick={this.handleClick} key={story.id} title={story.title} value={story.value} />
          ))
        }
      </table>
    </div>
      ;
  }
}

export default History;
