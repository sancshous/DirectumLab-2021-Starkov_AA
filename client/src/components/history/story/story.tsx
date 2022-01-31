import * as React from "react";
import remove from "../../../images/remove.svg";
import Button from "../../button/button";
import "./story.css";

interface IProps {
  title: string,
  value: string,
  onClick: () => void
}

const Story: React.FC<IProps> = (props) => {
  return <tr onClick={props.onClick} className="history__story">
    <td>{props.title}</td>
    <td className="history__story-value">{props.value}</td>
    <td>
      <Button className={'history__story-btnDelete'} title={<img src={remove} />} />
    </td>
  </tr>
    ;
}

export default Story;
