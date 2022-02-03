import * as React from 'react';
import CreatePage from "../login-page/create-page";
import InvitePage from "../login-page/invite-page";
import NoMatchPage from "../no-match-page/no-match-page";
import RoomPage from "../room-page/room-page";
import {Switch, Route} from 'react-router-dom';
import {RoutePath} from "../../routes";
import {store} from "../../store/mockStore";
import './app.css';


const App: React.FunctionComponent = () => {
  return <Switch>
    <Route path={RoutePath.INDEX} exact={true} component={CreatePage} />
    <Route path={`${RoutePath.ROOM}/:roomId`} exact={true} component={RoomPage} />
    {/*<Route*/}
    {/*  path={`${RoutePath.ROOM}/:roomId`}*/}
    {/*  exact={true}*/}
    {/*  render={() => <RoomPage user={store.user} room={store.room} />} />*/}
    <Route path={`${RoutePath.INVITE}/:roomId`} exact={true} component={InvitePage} />
    <Route component={NoMatchPage} />
  </Switch>
};

export default App;
