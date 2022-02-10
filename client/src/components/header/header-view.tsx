import * as React from "react";
import Logo from "../logo/logo";
import User from "../user/user";
import './header.css';

interface IUser {
  name: string
}

interface IProps {
  user: IUser | null;
}

const HeaderView: React.FC<IProps> = (props) => {
  return <header className="header">
    <div className="container header__content">
      <Logo />
      {props.user != null && <User name={props.user.name} />}
    </div>
  </header>
  ;
}

export default HeaderView;
