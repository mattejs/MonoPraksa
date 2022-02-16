import React, { Component } from 'react';

class Time extends Component {
    constructor(props){
        super(props);
        this.state ={time: new Date().toLocaleTimeString()}
    }

    componentDidMount() {
        this.intervalID = setInterval(() => this.updateClock(), 1000);
    }

    componentWillUnmount(){
        clearInterval(this.intervalID)
    }

    updateClock(){
        this.setState({
            time: new Date().toLocaleTimeString()
        });
    }

    render() {
        return (
            <div className="Time">
                <h2>Time : {this.state.time} </h2>
            </div>
        );}
    }

export default Time;