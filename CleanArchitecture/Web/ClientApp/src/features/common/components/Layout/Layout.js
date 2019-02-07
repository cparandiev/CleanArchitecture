import React, { Component } from 'react';
import "./layout.scss";

export class Layout extends Component {
  render() {
    return (
      <main className="main-layout">
        <div className="container">
            {this.props.children}
        </div>
      </main>
    );
  }
}
