import React, { Component } from 'react';
import './Card.css'

class Card extends Component {
    render(){
        return(
            <div className="card__container">
                {this.props.cardName}
            </div>
        );
    }
}
export default Card;