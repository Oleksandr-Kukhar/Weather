import React, { Component } from 'react';
import Bootstrap from 'bootstrap';
import axios from 'axios';
import { Container, Row, Col } from 'reactstrap';

export class Home extends Component {
  state = {
    date: "",
    time: "",
    temperature: 0,
    pressure: 0,
    humidity: 0,
    windSpeed: 0,
    windDirection: 0,
    windDirectionStr: "",
    loading: false
  }

  startFetchingWeather = async () => {
    const that = this;
    if (!this.state.loading) {
      const data = (await axios.get("getsensordata")).data;
      that.setState({ date: data.date, time: data.time, temperature: data.temperature, pressure: data.pressure, humidity: data.humidity, windDirection: data.windDirection, windSpeed: data.windSpeed, windDirectionStr: data.windDirectionStr});
      setInterval(async () => {
        const data = (await axios.get("getsensordata")).data;
        that.setState({ date: data.date, time: data.time, temperature: data.temperature, pressure: data.pressure, humidity: data.humidity, windDirection: data.windDirection, windSpeed: data.windSpeed, windDirectionStr: data.windDirectionStr });
      }, 60000);
      that.setState({ loading: true });
    }
  }

  //vertity = () => {
  //  const that = this
  //  setInterval(() => { that.setState({ windDirection: that.state.windDirection + 1 }) }, 10)
  //}
  //componentDidMount = () => {
  //  this.vertity();
  //}

  render() {
    this.startFetchingWeather();
    return (
      <Container fluid>
        <Row>
          <Col></Col>
          <Col sm={6} className="bg-light rounded p-3">
            <Row>
              <Col sm={6}>
                <h2>Weather Station</h2>
                <p><strong>Date:</strong> {this.state.date}</p>
                <p><strong>Time:</strong> {this.state.time}</p>
                <p><strong>Temperature:</strong> {this.state.temperature - 273}&#176;C</p>
                <p><strong>Pressure:</strong> {this.state.pressure} hPa</p>
                <p><strong>Humidity:</strong> {this.state.humidity}%</p>
                <p><strong>Wind Speed:</strong> {this.state.windSpeed} m/s</p>
                <p><strong>Wind Direction:</strong> {this.state.windDirectionStr} {this.state.windDirection}&#176;</p>
              </Col>
              <Col>
                <img src={require('./img/directions.jpg')} style={{ transform: `rotate(${-this.state.windDirection}deg)`, margin: `50px`, borderRadius: `1000px`, borderStyle: `solid`, width: `75%`}}></img>
              </Col>
            </Row>
          </Col>
          <Col></Col>
        </Row>
      </Container>
    );
  }
}
