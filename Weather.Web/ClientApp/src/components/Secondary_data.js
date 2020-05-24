import React, { Component } from 'react';
import Bootstrap from 'bootstrap';
import axios from 'axios';
import { Container, Row, Col } from 'reactstrap';

export class Secondary_data extends Component {

  state = {
    dewPoint: 0,
    windChill: 0,
    minTemp: 0,
    maxTemp: 0,
    minPress: 0,
    maxPress: 0,
    minHum: 0,
    maxHum: 0,
    minTempTime: 0,
    maxTempTime: 0,
    minPressTime: 0,
    maxPressTime: 0,
    minHumTime: 0,
    maxHumTime: 0,
    loading: false
  }

  startFetchingSecondaryData = async () => {
    const that = this;
    if (!this.state.loading) {
      const data = (await axios.get("getsecondarydata")).data;
      that.setState({
        dewPoint: data.dewPoint,
        windChill: data.windChill,
        minTemp: data.minimalTemperature,
        maxTemp: data.maximalTemperature,
        maxHum: data.maximalHumidity,
        minHum: data.minimalHumidity,
        minPress: data.minimalPressure,
        maxPress: data.maximalPressure,
        minTempTime: data.minimalTemperatureTime,
        maxTempTime: data.maximalTemperatureTime,
        maxHumTime: data.maximalHumidityTime,
        minHumTime: data.minimalHumidityTime,
        minPressTime: data.minimalPressureTime,
        maxPressTime: data.maximalPressureTime
      });
      setInterval(async () => {
        const data = (await axios.get("getsecondarydata")).data;
        that.setState({
          dewPoint: data.dewPoint,
          windChill: data.windChill,
          minTemp: data.minimalTemperature,
          maxTemp: data.maximalTemperature,
          maxHum: data.maximalHumidity,
          minHum: data.minimalHumidity,
          minPress: data.minimalPressure,
          maxPress: data.maximalPressure,
          minTempTime: data.minimalTemperatureTime,
          maxTempTime: data.maximalTemperatureTime,
          maxHumTime: data.maximalHumidityTime,
          minHumTime: data.minimalHumidityTime,
          minPressTime: data.minimalPressureTime,
          maxPressTime: data.maximalPressureTime
        });
      }, 60000);
      that.setState({ loading: true });
    }
  }

  render() {
    this.startFetchingSecondaryData();
    return (
      <Container fluid>
        <Row>
          <Col></Col>
          <Col sm={6} className="bg-light rounded p-3">
                <h2>Secondary Data</h2>
                <p><strong>Dew point:</strong> {this.state.dewPoint - 273}&#176;C</p>
                <p><strong>Wind Chill:</strong> {this.state.windChill - 273}&#176;C</p>
                <p><strong>Maximal Temperature:</strong> {this.state.maxTemp - 273}&#176;C <strong>Time:</strong> {this.state.maxTempTime}</p>
                <p><strong>Minimal Temperature:</strong> {this.state.minTemp - 273}&#176;C <strong>Time:</strong> {this.state.minTempTime}</p>
                <p><strong>Maximal Pressure:</strong> {this.state.maxPress} hPa <strong>Time:</strong> {this.state.maxPressTime}</p>
                <p><strong>Minimal Pressure:</strong> {this.state.minPress} hPa <strong>Time:</strong> {this.state.minPressTime}</p>
                <p><strong>Maximal Humidity:</strong> {this.state.maxHum}% <strong>Time:</strong> {this.state.maxHumTime}</p>
                <p><strong>Minimal Humidity:</strong> {this.state.minHum}% <strong>Time:</strong> {this.state.minHumTime}</p>
          </Col>
          <Col></Col>
        </Row>
      </Container>
    );
  }
}
