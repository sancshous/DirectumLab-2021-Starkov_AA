import * as React from "react";
import {withRouter} from "react-router-dom";
import {RouteComponentProps} from "react-router";
import Header from "../header/header";
import Form from "./form/form";
import Footer from "../footer/footer";
import {RoutePath} from "../../routes";

const CreatePage: React.FC<RouteComponentProps> = (props) => {
  const handleClick = () => {
    const roomId = Math.round(Math.random() * (100 - 1) + 1);
    props.history.push(`${RoutePath.ROOM}/${roomId}`);
  }

  return <div className={'body'}>
    <Header user={null} />
    <main className="main">
      <div className="container main__content">
        <Form onSubmit={handleClick} loginPage={'create'} />
      </div>
    </main>

    <Footer />
  </div>
    ;
}

export default withRouter(CreatePage);
