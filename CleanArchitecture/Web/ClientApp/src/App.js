import React, { Component } from 'react';
import { Route } from 'react-router';
import { MDBContainer, MDBRow, MDBCol } from "mdbreact";

import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';
import Navigation from './features/navigation';

export default class App extends Component {
  style = {
    color: "red",
    fontSize: 20,
    border: "1px solid green"
    };

  render() {
    return (
      <React.Fragment>
          <Navigation/>
          <Route exact path='/' component={Home} />
          <Route path='/counter' component={Counter} />
          <Route path='/fetchdata' component={FetchData} />
      </React.Fragment>
    );
  }
}