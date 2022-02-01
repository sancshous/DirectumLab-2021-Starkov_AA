import * as React from "react";
import ModalContent from "./modal-content";
import "./modal.css";

interface IProps {
  className?: string | null
}

interface IState {
  isOpened: boolean
}

class Modal extends React.Component<IProps, IState>{

  constructor(props: IProps) {
    super(props);
    this.state = {
      isOpened: true
    }
  }

  handleClick = () => {
    this.setState({
      isOpened: false
    })
  }

  render() {
    const {isOpened} = this.state;
    return <div className={`modal__wrapper ${!isOpened && ' visually-hidden'}`}>
      <ModalContent onSubmit={this.handleClick} />
    </div>
      ;
  }
}

export default Modal;
