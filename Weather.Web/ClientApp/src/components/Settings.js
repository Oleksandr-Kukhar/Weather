import React, { Component } from 'react';
import axios from 'axios';
import { Container, Row, Col, InputGroup, InputGroupAddon, Input, InputGroupText } from 'reactstrap';

export class Settings extends Component {

  state = {
    maxValue:15,
    minValue: 5,
    id:0,
  }

  startFetching = () => {
    axios.get("startretrievingdata")
  }

  stopFetching = () => {
    axios.get("stopretrievingdata")
  }

  handleForm = (event) => {
    this.setState({ [event.target.name]: event.target.value });
    console.log("Handled form")
  }

  changeMaxValueHandler = (event) => {
    this.setState({ maxValue: event.target.value });
    console.log("Handled max", this.state.maxValue);
  }

  changeMinValueHandler = (event) => {
    this.setState({ minValue: event.target.value });
    console.log("Handled min", this.state.minValue);
  }

  handleButton = (event) => {
    if (event.target.name ==="temperatura") {
      this.setState({ id: 1 });
    }
    if (event.target.name === "spid") {
      this.setState({ id: 4 });
    }
    if (event.target.name === "tisk") {
      this.setState({ id: 3 });
    }
    if (event.target.name === "vologist") {
      this.setState({ id: 2 });
    }
    console.log("handled button")
  }

  changeValuesSensor = () => {
    console.log(this.state.id);
    console.log(this.state.maxVal);
    console.log(this.state.minValue);
    axios.get(`change/${this.state.id}/${this.state.minValue}/${this.state.maxValue}`);
  }

  render() {
    return (
      <Container fluid>
        <Row>
          <Col></Col>
          <Col className="bg-light rounded m-3 p-3">
            <h2>Calibrate Sensors</h2>
              <div className="p-3">
              <Input value={this.state.maxValue} onChange={this.changeMaxValueHandler} placeholder="Set maximal value" />
                <br />
              <Input value={this.state.minValue} onChange={this.changeMinValueHandler} placeholder="Set minimal value" />
              </div>
              <Row>
                <Col>
                  <p><button name="temperatura" onClick={this.handleButton} className="btn btn-outline-dark btn-block">Temperature</button> </p>
                  <p><button name="spid" onClick={this.handleButton} className="btn btn-outline-dark btn-block">Wind speed</button> </p>
                </Col>
                <Col>
                  <p><button name="tisk" onClick={this.handleButton} className="btn btn-outline-dark btn-block">Pressure</button> </p>
                  <p><button name="vologist" onClick={this.handleButton} className="btn btn-outline-dark btn-block">Humidity</button> </p>
                </Col>
              </Row>
            <button className="btn btn-outline-dark btn-block" onClick={this.changeValuesSensor}>Change Values</button>
            <Col>
            </Col>
            <h2>Fetch Data</h2>
            <Row className>
              <Col>
                <button className="btn btn-outline-dark btn-block" onClick={this.startFetching}>Start Fetching Data</button>
              </Col>
              <Col>
                <button className="btn btn-outline-dark btn-block" onClick={this.stopFetching}>Stop Fetching Data</button>
              </Col>
            </Row>
          </Col>
          <Col></Col>
        </Row>
      </Container>
    );
  }
}
