import React from 'react';
import List from './List';
import { BASE_URL } from '../constants';
import { withRouter } from 'react-router-dom';
import './Board.css'
import axios from 'axios';


class Board extends React.Component{

    constructor(){ 
        super();
        this.state = {
            boardName: '',
            boardId: 0,
            boardData: [],
            listName: " "
        }
    }


    componentDidMount(){
        axios.get(BASE_URL+ '/board').then((response) => {
            console.log(response);
            this.setState({
                boardData: response.data.lists,
                boardName: response.data.name, 
                boardId: response.data.id,
        });
     }).catch(()=> {
         this.props.history.push('/new');
     });
    }

    renderLists = () => {
        return this.state.boardData.map((list) => 
            <List key={list.id} boardId={this.state.boardId} listId={list.id} listName={list.name} cards={list.cards} deleteList={this.deleteList}/>
        );
    }

    getCardsExceptCardWithSpecifedId = (id) => {
        return this.state.boardData.filter(card => card.id !== id);
    }
    deleteList = (id) => {
        return axios.delete(BASE_URL+"/list", {
            params: {listId: id}
        })
        .then(response => {
            this.setState({ boardData: this.getCardsExceptCardWithSpecifedId(id)});
        })
        .catch(error => {
            console.log(error);
        });
    }

    onChangeListName = (e) => {
        this.setState({ listName: e.target.value});
    }

    onClickListName = (e) => {
        e.preventDefault();
        axios.post(BASE_URL+"/list", {boardid: this.state.boardId, name: this.state.listName})
            .then(response => {
                console.log(response);
                this.setState(prevState => {
                    return {
                        boardData: [...prevState.boardData, response.data],
                        listName: ''
                    }
                });
            });
    }

    render(){
        return(
            <div>
                <div>
                    <div>
                        {this.state.boardName}
                    </div>
                    <button disabled={!this.state.listName} className="btn btn-info" onClick={this.onClickListName}>Add new list</button>
                    <input type="text" className="listName__input" value={this.state.listName} onChange={this.onChangeListName}/>
                </div>
                <div className="container-fluid">
                    <div className="row flex-row flex-nowrap">
                         {this.renderLists()}
                    </div>
                </div>
            </div>
        );
    }
}

export default withRouter(Board);