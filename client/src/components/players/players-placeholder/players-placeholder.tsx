import * as React from "react";
import Button from "../../button/button";
import '../players.css';


interface IProps {
 inputRef:  React.RefObject<HTMLInputElement>,
  handleSubmit: () => void
}

const PlayersPlaceholder: React.FC<IProps> = (props) => {

  return <div>
    <input ref={props.inputRef} className="players__input players__storyname" type="text" placeholder="I" required={true} />
    <Button onClick={props.handleSubmit} className={'players__btn-next'} title={'Go'} />
  </div>

}

export default PlayersPlaceholder;
