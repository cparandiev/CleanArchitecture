import React, { Component } from 'react';
import { connect } from 'react-redux';

import Navbar from "./components/Navbar";
import {userSelector, currentRouteSelector} from "../common/selectors";
import mergeSelectors from "../../utils/mergeSelectors";

class Navigation extends Component {
    
    render() {
        const {currentRoute, user} = this.props;
        
        return (
            <Navbar currentRoute={currentRoute} user={user}/>
        );
    }
}

const selectors = [currentRouteSelector, userSelector];

const mapStateToProps = mergeSelectors(selectors);


export default connect(mapStateToProps)(Navigation);