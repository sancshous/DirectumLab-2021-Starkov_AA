import * as React from "react";
import download from "../../../images/download.svg";
import Button from "../../button/button";
import "./history-header.css";

interface IProps {
  mark: number | undefined
}

const HistoryHeader: React.FC<IProps> = (props) => {
  return <header className="history__header">
    <div className="history__header-container">Completed Stories
      <div className="history__mark">{props.mark}</div>
    </div>
    <Button className={'history__btn-download'} title={<img src={download} />} />
  </header>
    ;
}

export default HistoryHeader;
