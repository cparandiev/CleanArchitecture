import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter } from 'react-router-dom';
import { Provider } from 'react-redux'
import "bootstrap-css-only/css/bootstrap.min.css";
import "mdbreact/dist/css/mdb.css";

import App from './App';
import registerServiceWorker from './registerServiceWorker';
import store from "./store";

const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');
const rootElement = document.getElementById('root');


ReactDOM.render(
  <Provider store={store}>   
    <BrowserRouter basename={baseUrl}>
      <App />
    </BrowserRouter> 
  </Provider>,
  rootElement);

registerServiceWorker();
