import * as React from "react";
import {Link} from "react-router-dom";
import './footer.css';
import {RoutePath} from "../../routes";

const Footer: React.FC = () => {
  return <footer className="footer">
    <p>Copyright 2021 <Link className="footer__text" to={RoutePath.INDEX}>PlanPoker</Link></p>
  </footer>
    ;
}

export default Footer;
