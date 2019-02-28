import React, { Component } from 'react';
import { connect } from "react-redux";

import { accomplishMedicalExamination } from "./actions";

class AccomplishMedicalExamination extends Component {
    state = {notes: ""}

    handleChange = (e) => {const value = e.target.value; this.setState((state) => ({...state, notes: value}));}

    render() {
        const {notes} = this.state;
        const {match: {params : {id}}, accomplishMedicalExamination} = this.props;

        return (
            <div className="container">
                <div className="row">
                    <div className="col">
                        <div className="card">
                            <div className="card-body">
                                <div className="row">
                                    <div className="col">
                                        <h5 className="card-title">Accomplish Medical Examination</h5>
                                    </div>                        
                                </div>
                                <div className="row justify-content-md-center">
                                    <div className="col-1 col-form-label">
                                        <label className="title" htmlFor="notes">Notes</label>
                                    </div>
                                    <div className="col">
                                        <input type="text" className="form-control" id="notes" placeholder="Notes" value={notes} onChange={this.handleChange}/>
                                    </div>
                                </div>
                                <div className="text-center">
                                    <button type="button" className="btn btn-primary" onClick={() => accomplishMedicalExamination(id, notes)}>Accomplish</button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        );
    }
}

const mapDispatchToProps = (dispatch) => ({
    accomplishMedicalExamination: (requestId, notes) => dispatch(accomplishMedicalExamination.actions.DEFAULT({requestId, notes}))
});

export default connect(null, mapDispatchToProps)(AccomplishMedicalExamination);