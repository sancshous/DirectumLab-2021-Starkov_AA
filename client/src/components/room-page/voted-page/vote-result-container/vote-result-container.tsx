import * as React from "react";
import ResultInfo from "./result-info/result-info";
import Donut from "../donut/donut";
import "./vote-result-container.css";

interface IProps {
  playersQuantityVoted: number | null,
  average: number | null,
  valueVotes: number[] | null,
  valueLabels: string[] | null
}

const VoteResultContainer: React.FC<IProps> = (props) => {
  return <div className="vote-result">
    <div className="ring">
      <Donut series={props.valueVotes} labels={props.valueLabels} />
      <ResultInfo playersQuantityVoted={props.playersQuantityVoted} average={props.average} />
    </div>
  </div>
    ;
}

export default VoteResultContainer;
