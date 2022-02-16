import React from "react";
import react from './react.png';

function Header(props) {
  return (
    <div>
      <header>
      <h1>{props.header}</h1>
      <img src={react} className="App-img" alt="react" />
      </header>
    </div>
  );
}

export default Header;