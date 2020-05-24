import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { Settings } from './components/Settings';
import { Secondary_data } from './components/Secondary_data';

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/Secondary_data' component={Secondary_data} />
        <Route path='/Settings' component={Settings} />
      </Layout>
    );
  }
}
