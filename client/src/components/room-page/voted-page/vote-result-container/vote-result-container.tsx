import * as React from "react";
import ResultInfo from "./result-info/result-info";
import StatInfo from "./stat-info/stat-info";
import "./vote-result-container.css";

const ring = <svg width="328px" height="328px" viewBox="0 0 42 42" className="donut">
  <circle className="donut-hole" cx="21" cy="21" r="15.91549430918954" fill="#fff" />
  <circle className="donut-ring" cx="21" cy="21" r="15.91549430918954" fill="transparent" stroke="#DC493A"
    strokeWidth="1.5" />
  <circle className="donut-segment" cx="21" cy="21" r="15.91549430918954" fill="transparent"
    stroke="#f4a460" strokeWidth="1.5" strokeDasharray="50 50" strokeDashoffset="25" />
</svg>

interface IProps {
  playersQuantityVoted: number | null,
  average: number | null,
  valueVotes: number[] | null
}

const VoteResultContainer: React.FC<IProps> = (props) => {
  return <div className="vote-result">
    <div className="ring">
      {ring}
      <ResultInfo playersQuantityVoted={props.playersQuantityVoted} average={props.average} />
    </div>
    <ul className="stat-group">
      {props.valueVotes?.map((value) => (
        // eslint-disable-next-line react/jsx-key
        <StatInfo value={value} />
      ))}
    </ul>
  </div>
    ;
}

export default VoteResultContainer;
