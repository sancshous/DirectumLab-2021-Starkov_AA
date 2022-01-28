import * as React from 'react';
import './app.css';
import FirstState from "../first-state/first-state";
import PlaningPage from "../planing-page/planing-page";
import LoginPage from "../login-page/login-page";
import ResultPage from "../result-page/result-page";

const PageMap: { [key: string]: React.ReactElement } = {
  '1': <LoginPage form={'form-create'} />,
  '2': <FirstState />,
  '3': <PlaningPage />,
  '4': <ResultPage />
};

const App: React.FunctionComponent = () => {
  const [page] = React.useState( 1);
  return PageMap[page];
};

export default App;
