import * as React from "react";
import './input.css';

interface IProps {
  label: string;
  placeholder: string;
}

const Input: React.FC<IProps> = (props) => {
  return <label className="form__label">{props.label}
    <input className="form__input" type="text" name="user-name" placeholder={props.placeholder} required={true} />
  </label>
  ;
}

export default Input;
