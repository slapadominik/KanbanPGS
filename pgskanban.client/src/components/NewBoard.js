import React, { Component } from 'react';
import {BASE_URL} from '../constants';
import { withRouter } from 'react-router-dom';
import axios from 'axios';

class NewBoard extends Component {
    constructor(){
        super();
        this.state = {
            name: '',
        };
    }
    handleSubmit = (e) => {
        axios.post(BASE_URL + '/board', {name: this.state.name}).then(() => {
            this.props.history.push('/');
        })
        .catch((err) => {
            console.log(err);
        });
    }

    handleChangeName = (e) => {
        this.setState({name: e.target.value})
    }

    render(){
        return(
            <div>
                <input value={this.state.name} onChange={this.handleChangeName} placeholder="Add new button" className="form-control"/>
                <button onClick={this.handleSubmit} disabled= {!this.state.name} className="btn btn-primary">Dodaj board</button>
            </div>
        );
    }
}

export default withRouter(NewBoard);