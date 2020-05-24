import React, { Component } from 'react';
import axios from 'axios';
import { Container, Row, Col, InputGroup, InputGroupAddon, Input, InputGroupText } from 'reactstrap';

export class Settings extends Component {

  startFetching = () => {
    axios.get("startretrievingdata")
  }

  stopFetching = () => {
    axios.get("stopretrievingdata")
  }

  render() {
    return (
      <Container fluid>
        <Row>
          <Col></Col>
          <Col className="bg-light rounded m-3 p-3">
            <h2>Calibrate Sensors</h2>
            <div className="p-3">
                  <InputGroup>
                    <Input placeholder="Set maximal value" />
                  </InputGroup>
                  <br />
                  <InputGroup>
                    <Input placeholder="Set minimal value" />
                  </InputGroup>
            </div>
            <Row>
                  <Col>
                    <p><button className="btn btn-outline-dark btn-block">Temperature</button> </p>
                    <p><button className="btn btn-outline-dark btn-block">Wind speed</button> </p>
                  </Col>
                  <Col>
                    <p><button className="btn btn-outline-dark btn-block">Pressure</button> </p>
                    <p><button className="btn btn-outline-dark btn-block">Humidity</button> </p>
                  </Col>
                </Row>

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
