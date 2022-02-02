import * as React from "react";
import './button.css';
import {ReactElement} from "react";

interface IProps {
  title: string | ReactElement,
  className?: string,
  onClick?: () => void
}

const Button: React.FC<IProps> = (props) => {
  return <button onClick={props.onClick} className={`btn ${props.className || ''}`} type="submit">{props.title}</button>;
}

export default Button;
