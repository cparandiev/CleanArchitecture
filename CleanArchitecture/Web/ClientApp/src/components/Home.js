import React, { Component } from 'react';
import Login from "../features/login";

export class Home extends Component {
  displayName = Home.name

  render() {
    return (
      <div>
        <Login />
      </div>
    );
  }
}
