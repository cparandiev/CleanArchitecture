import React, { Component } from 'react';
import { Route } from 'react-router';

import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';
import Navigation from './features/navigation';
import Layout from './features/common/components/Layout';

export default class App extends Component {
  render() {
    return (
      <React.Fragment>
        <Navigation/>
        <Layout>
            <Route exact path='/one' component={Home} />
            <Route path='/counter' component={Counter} />
            <Route path='/fetchdata' component={FetchData} />
        </Layout>
      </React.Fragment>
    );
  }
}