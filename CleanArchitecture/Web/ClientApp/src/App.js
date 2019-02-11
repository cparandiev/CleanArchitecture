import React, { Component } from 'react';

import Navigation from './features/navigation';
import Layout from './features/common/components/Layout';
import Routes from "./routes";

export default class App extends Component {
  render() {
    return (
      <React.Fragment>
        <Navigation/>
        <Layout>
          <Routes />    
        </Layout>
      </React.Fragment>
    );
  }
}