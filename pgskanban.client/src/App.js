import React, { Component } from 'react';
import logo from './logo.svg';
import './App.css';
import Board from './components/Board';
import { BrowserRouter, Route} from 'react-router-dom';
import NewBoard from './components/NewBoard';

class App extends Component {
  render() {
    return (
      <div className="App">
        <BrowserRouter>
          <div>
            <Route path="/new" component={NewBoard}/>
            <Route exact path="/" component={Board}/>
          </div>
        </BrowserRouter>
      </div>
    );
  }
}

export default App;
