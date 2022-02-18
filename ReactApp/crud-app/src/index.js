import React from 'react';
import ReactDOM from 'react-dom';
import 'bootstrap/dist/css/bootstrap.min.css';
import './index.css';
import App from './App';
import Tables from './Tables';
import Reviews from './Reviews';
import reportWebVitals from './reportWebVitals';
import NavbarComponent from './Navbar';
import {BrowserRouter as Router, Routes, Route} from 'react-router-dom';

ReactDOM.render(
  <React.StrictMode>
    <Router>
      <NavbarComponent />
      <Routes>
        <Route path="/" exact element={<Tables/>} />
        <Route path="/reviews" element={<Reviews/>} />
        
      </Routes>
    </Router>
  </React.StrictMode>,
  document.getElementById('root')
);



// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
