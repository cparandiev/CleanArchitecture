import React, { Component } from 'react';

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
          <Routes />    
        </Layout>
      </React.Fragment>
    );
  }
}