import * as React from "react";
import "./stat-info.css";

const li1 = <svg className="circle" width="10" height="10" viewBox="0 0 10 10" fill="none"
  xmlns="http://www.w3.org/2000/svg">
  <ellipse cx="5.09086" cy="5" rx="4.72727" ry="5" fill="#DC493A" />
</svg>

interface IProps {
  value: number
}

const StatInfo: React.FC<IProps> = (props) => {
  return <li className="stat">
    <div className="stat__title">
      {li1}
      <p className="stat__title-text">{props.value}</p>
    </div>
    {/*<p className="stat__text">50% (1 player)</p>*/}
  </li>
    ;
}

export default StatInfo;
