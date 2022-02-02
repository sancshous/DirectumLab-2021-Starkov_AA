import * as React from "react";
import Input from "../../input/input";
import './form.css';
import Button from "../../button/button";

interface IProps {
  loginPage: string,
  onSubmit: () => void
}

const Form: React.FC<IProps> = (props) => {

  function renderCreateForm() {
    return <div>
      <p className="form__text">Create the room:</p>
      <Input label={'User name'} placeholder={'Enter your name'} />
      <Input label={'Room name'} placeholder={'Enter room name'} />
    </div>
  }

  function renderInviteForm() {
    return <div>
      <p className="form__text">Join the room:</p>
      <Input label={'User name'} placeholder={'Enter your name'} />
    </div>
  }

  return <form className="form">
    {/* eslint-disable-next-line react/no-unescaped-entities */}
    <h2 className="form__title">Let's Start!</h2>
    {props.loginPage === 'create' ? renderCreateForm() : renderInviteForm()}
    <Button onClick={props.onSubmit} className={'form__btn'} title={'Enter'} />
  </form>
    ;
}

export default Form;
