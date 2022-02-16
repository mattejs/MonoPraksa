import React from "react";
import { useState } from "react";

function NameForm(props) {
    const [name, setName] = useState("");
  
    return (
      <form>
        <label>Enter your name:
          <input 
            type="text" 
            value={name}
            onChange={(e) => setName(e.target.value)}
          />
        </label>
        <p>
            Hi {name}!
        </p>
        <p>
            Props message: {props.message}
        </p>
      </form>      
    )
  }

  export default NameForm