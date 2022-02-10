import React from 'react';
import {Router} from "react-router-dom";
import ReactDOM from 'react-dom';
import App from './components/app/app';
import {history} from "./history";
import {createStore} from 'redux';
import {Provider} from 'react-redux';
import {composeWithDevTools} from 'redux-devtools-extension';
import {reducer} from "./store/reducer";
import './index.css';

const store = createStore(reducer, composeWithDevTools());

ReactDOM.render(
  <React.StrictMode>
    <Provider store={store}>
      <Router history={history}>
        <App />
      </Router>
    </Provider>
  </React.StrictMode>,
  document.getElementById(`root`)
);
