import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap/dist/css/bootstrap-theme.css';
import './index.css';
import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter } from 'react-router-dom';
import { Provider } from 'react-redux'
import { createStore } from 'redux'

import App from './App';
import registerServiceWorker from './registerServiceWorker';
import rootReducer from "./reducers";

const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');
const rootElement = document.getElementById('root');
const store = createStore(rootReducer)

ReactDOM.render(
  <Provider store={store}>
    <BrowserRouter basename={baseUrl}>
      <App />
    </BrowserRouter>
  </Provider>,
  rootElement);

registerServiceWorker();
