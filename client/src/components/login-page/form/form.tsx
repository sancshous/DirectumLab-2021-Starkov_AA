import * as React from "react";
import Button from "../../button/button";
import Input from "../../input/input";
import './form.css';

interface IProps {
  loginPage: string;
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
    <Button className={'form__btn'} title={'Enter'} />
  </form>
    ;
}

export default Form;
