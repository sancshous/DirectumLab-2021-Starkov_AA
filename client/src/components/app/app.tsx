import * as React from 'react';
import CreatePage from "../login-page/create-page/create-page";
import InvitePage from "../login-page/invite-page/invite-page";
import NoMatchPage from "../no-match-page/no-match-page";
import RoomPage from "../room-page/room-page";
import {Switch, Route} from 'react-router-dom';
import {RoutePath} from "../../routes";
import ErrorPage from "../error-page/error-page";
import './app.css';


const App: React.FunctionComponent = () => {
  return <Switch>
    <Route path={RoutePath.INDEX} exact={true} component={CreatePage} />
    <Route path={`${RoutePath.ROOM}/:roomId`} exact={true} component={RoomPage} />
    <Route path={`${RoutePath.INVITE}/:roomId`} exact={true} component={InvitePage} />
    <Route path={`${RoutePath.ERROR}`} exact={true} component={ErrorPage} />
    <Route component={NoMatchPage} />
  </Switch>
};

export default App;
