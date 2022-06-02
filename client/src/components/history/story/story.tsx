import * as React from "react";
import "./story.css";

interface IProps {
  title: string,
  average: number | null,
  onClick: (discussionId: string) => void,
  discussionId: string
}

const Story: React.FC<IProps> = (props) => {
  return <div onClick={() => props.onClick(props.discussionId)}>
    <tr className="history__story">
      <td>{props.title}</td>
      <td className="history__story-value">{props.average}</td>
    </tr>
  </div>
    ;
}

export default Story;
