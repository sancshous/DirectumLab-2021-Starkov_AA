import * as React from "react";
import HistoryHeader from "./history-header/history-header";
import Story from "./story/story";
import "./history.css";

interface IStory {
  id: number,
  title: string,
  value: string
}

interface IStories {
  story: IStory
}

const stories: IStories[] = [
  {story: {id: 1, title: 'Планирование', value: '15'}},
  {story: {id: 2, title: 'Подведение итогов', value: '22'}},
  {story: {id: 3, title: 'Корпоратив', value: '6'}},
  {story: {id: 4, title: 'Подведение итогов', value: '22'}},
  {story: {id: 5, title: 'Подведение итогов', value: '22'}}
]

const History: React.FC = () => {
  return <div className="history">
    <HistoryHeader mark={stories.length} />
    <table className="history__body">
      {
        stories.map((foo) => (
          <Story key={foo.story.id} title={foo.story.title} value={foo.story.value} />
        ))
      }
    </table>
  </div>
  ;
}

export default History;
