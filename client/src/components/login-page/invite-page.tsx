import * as React from "react";
import Header from "../header/header";
import Footer from "../footer/footer";
import {withRouter} from "react-router-dom";
import {RouteComponentProps} from "react-router";
import Form from "./form/form";
import {RoutePath} from "../../routes";

interface IMatchParams {
  roomId: string;
}

const InvitePage: React.FC<RouteComponentProps<IMatchParams>> = (props) => {
  const handleClick = () => {
    props.history.push(`${RoutePath.ROOM}/${props.match.params.roomId}`);
  }


  return <div className={'body'}>
    <Header user={null} />
    <main className="main">
      <div className="container main__content">
        <Form onSubmit={handleClick} loginPage={'invite'} />
      </div>
    </main>

    <Footer />
  </div>
    ;
}

export default withRouter(InvitePage);
