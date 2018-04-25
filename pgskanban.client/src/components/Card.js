import React, { Component } from 'react';
import './Card.css'

class Card extends Component {
    render(){
        return(
            <div className="card__container">
                <p>{this.props.cardName}</p>
            </div>
        );
    }
}
export default Card;