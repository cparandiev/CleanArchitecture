import React, { Component } from 'react';

import "./layout.css";

export class Layout extends Component {
  render() {
    return (
      <div className="container main-layout">
            {this.props.children}
      </div>
    );
  }
}
