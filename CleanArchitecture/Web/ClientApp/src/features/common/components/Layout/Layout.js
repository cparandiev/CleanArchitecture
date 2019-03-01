import React, { Component } from 'react';

import "./layout.css";

export class Layout extends Component {
  render() {
    return (
      <div className="main-layout">
        <div className="container page-content">
            {this.props.children}
        </div>
      </div>
    );
  }
}
