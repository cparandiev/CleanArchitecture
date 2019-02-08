import React from 'react';
import ReactDOM from 'react-dom';
import { Provider } from 'react-redux';
import { ConnectedRouter } from 'connected-react-router';
import 'jquery';
import 'popper.js';
import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap/dist/js/bootstrap.js';

import App from './App';
import registerServiceWorker from './registerServiceWorker';
import store from "./store";
import "./styles/index.css";
import {history} from "./store/configureStore";

ReactDOM.render(
  <Provider store={store}>   
    <ConnectedRouter history={history}>
      <App />
    </ConnectedRouter> 
  </Provider>,
  document.getElementById('root')
);

registerServiceWorker();
