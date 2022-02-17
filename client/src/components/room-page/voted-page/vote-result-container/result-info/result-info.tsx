import * as React from "react";
import "./result-info.css";

interface IProps {
  playersQuantityVoted: number | null,
  average: number | null
}

const ResultInfo: React.FC<IProps> = (props) => {
  return <div className="result">
    <p className="result__text">{props.playersQuantityVoted} Playes</p>
    <p className="result__text-small">voted</p>
    <p className="result__text">Avg: {props.average}</p>
  </div>
    ;
}

export default ResultInfo;
