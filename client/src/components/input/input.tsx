import * as React from "react";
import './input.css';

interface IProps {
  label: string;
  placeholder: string;
}

// eslint-disable-next-line react/display-name
const Input = React.forwardRef ((props: IProps, ref: React.ForwardedRef<HTMLInputElement>) => {
  return (
    <label className="form__label">{props.label}
      <input
        ref={ref}
        className="form__input"
        type="text"
        name="user-name"
        placeholder={props.placeholder}
        required={true} />
    </label>
  );
});

export default Input;
