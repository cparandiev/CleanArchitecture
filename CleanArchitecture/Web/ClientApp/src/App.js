import React, { Component } from 'react';
import { Switch } from 'react-router-dom';

import Navigation from './features/navigation';
import Layout from './features/common/components/Layout';
import Routes from "./routes";
import Notifications from './features/notifications';

export default class App extends Component {
  render() {
    return (
      <React.Fragment>
        <Notifications/>
        <Navigation/>
        <Layout>
          <Switch>
            <Routes />    
          </Switch>
        </Layout>
      </React.Fragment>
    );
  }
}