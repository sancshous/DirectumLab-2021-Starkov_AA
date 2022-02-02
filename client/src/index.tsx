import React from 'react';
import {Router} from "react-router-dom";
import ReactDOM from 'react-dom';
import App from './components/app/app';
import {history} from "./history";
import './index.css';

ReactDOM.render(
  <React.StrictMode>
    <Router history={history}>
      <App />
    </Router>
  </React.StrictMode>,
  document.getElementById(`root`)
);
