import * as React from "react";
import "./result-info.css";

const ResultInfo: React.FC = () => {
  return <div className="result">
    <p className="result__text">2 Playes</p>
    <p className="result__text-small">voted</p>
    <p className="result__text">Avg: 4</p>
  </div>
    ;
}

export default ResultInfo;
