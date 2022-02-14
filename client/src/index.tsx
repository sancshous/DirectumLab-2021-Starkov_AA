import React from 'react';
import {Router} from "react-router-dom";
import ReactDOM from 'react-dom';
import App from './components/app/app';
import {history} from "./service/history";
import {createStore, applyMiddleware} from 'redux';
import {Provider} from 'react-redux';
import {composeWithDevTools} from 'redux-devtools-extension';
import {reducer} from "./store/reducer";
import thunk from "redux-thunk";
import './index.css';

const store = createStore(reducer, composeWithDevTools(applyMiddleware(thunk)));

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
