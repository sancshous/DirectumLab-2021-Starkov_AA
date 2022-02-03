import * as React from "react";
import Input from "../../input/input";
import Button from "../../button/button";
import './form.css';

interface IProps {
  loginPage: string,
  onSubmit: (evt: React.FormEvent) => void,
  userRef: React.RefObject<HTMLInputElement>,
  roomRef?: React.RefObject<HTMLInputElement>
}

const Form: React.FC<IProps> = (props) => {

  function renderCreateForm() {
    return <div>
      <p className="form__text">Create the room:</p>
      <Input ref={props.userRef} label={'User name'} placeholder={'Enter your name'} />
      <Input ref={props.roomRef} label={'Room name'} placeholder={'Enter room name'} />
    </div>
  }

  function renderInviteForm() {
    return <div>
      <p className="form__text">Join the room:</p>
      <Input ref={props.userRef} label={'User name'} placeholder={'Enter your name'} />
    </div>
  }

  return <form className="form" onSubmit={props.onSubmit}>
    {/* eslint-disable-next-line react/no-unescaped-entities */}
    <h2 className="form__title">Let's Start!</h2>
    {props.loginPage === 'create' ? renderCreateForm() : renderInviteForm()}
    <Button className={'form__btn'} title={'Enter'} type={'submit'} />
  </form>
    ;
}

export default Form;
