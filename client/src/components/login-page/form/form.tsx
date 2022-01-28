import * as React from "react";
import Button from "../../button/button";
import Input from "../../input/input";
import './form.css';

interface IProps {
  loginPage: string;
}

const Form: React.FC<IProps> = (props) => {
  if (props.loginPage === 'create')
  {
    return <form className="form">
      {/* eslint-disable-next-line react/no-unescaped-entities */}
      <h2 className="form__title">Let's Start!</h2>
      <p className="form__text">Create the room:</p>

      <Input label={'User name'} placeholder={'Enter your name'} />
      <Input label={'Room name'} placeholder={'Enter room name'} />

      <Button className={'form__btn'} title={'Enter'} />
    </form>
      ;
  }
  else
  {
    return <form className="form">
      {/* eslint-disable-next-line react/no-unescaped-entities */}
      <h2 className="form__title">Let's Start!</h2>
      <p className="form__text">Join the room:</p>

      <Input label={'User name'} placeholder={'Enter your name'} />

      <Button className={'form__btn'} title={'Enter'} />
    </form>
      ;
  }
}

export default Form;
