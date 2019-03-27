import React, { Component } from 'react';

class BodyExaminationItem extends Component {
    componentWillUnmount() {
        const {onDisconnect} = this.props;

        onDisconnect();
    }

    render() {
        const {imgSrc, imgTitle, handleClick} = this.props;

        return (
            <div className="col img-wrapper" onClick={handleClick}>
                <img src={imgSrc} className="img-fluid" />
                <div className="carousel-caption">
                    <h5 className="img-text">{imgTitle}</h5>
                </div>
            </div>
        );
    }
}

export default BodyExaminationItem;    