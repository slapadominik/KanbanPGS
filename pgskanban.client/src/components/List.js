import React, { Component } from 'react';
import Card from './Card'
import './List.css'
import axios from 'axios';
import { BASE_URL } from '../constants';

class List extends Component {

    constructor(props){
        super(props);
        this.state = {
            name: props.listName,
            cards: this.props.cards,
            cardName: ""
        };
    }

    renderCards = () => {
        return this.state.cards.map((card) => <Card key={card.cardId} cardName={card.cardName}/>);
    }

    onListNameChange = (e) => {
        this.setState({name: e.target.value});
    }
    
    saveCard = () => {
        axios.post(BASE_URL+"/card", {CardName: this.state.cardName, ListId: this.props.listId})
        .then(response => {
            console.log(response);
            this.setState(prevState =>{
                return {
                    cards: [...prevState.cards, response.data]
                }
            });
        }).catch(error => {
            console.log(error);
        });
    }

    saveListName = () => {
        return axios.put(BASE_URL+"/list", {name: this.state.name, boardId: this.props.boardId, listId: this.props.listId})
        .then(() => {
            console.log("Successfully edited list!")
        }).catch((error) => {
            console.log(error);
        });
    }

    cardNameOnChange = (e) => {
        this.setState({cardName: e.target.value});
    }

   

    render(){
        return(
            <div className="col-3"> 
                <div className="row">
                    <input  value={this.state.name} onChange={this.onListNameChange}  className="form-control col-8" />
                    <button onClick={this.saveListName} className="btn btn-success">Edit</button>
                    <button className="btn btn-danger btn-danger col-2 btn-block" onClick={() => this.props.deleteList(this.props.listId)}>X</button>
                </div>
                <div className="card card-block">
                    {this.renderCards()}
                </div>
                <div>
                    <input type="text" value={this.state.cardName} onChange={this.cardNameOnChange}/>
                </div>
                <button className="btn btn-warning btn-sm" onClick={this.saveCard}>Add Card</button>   
                
            </div>
        );
    }
}

export default List;