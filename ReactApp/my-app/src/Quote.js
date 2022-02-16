import React, {useState} from 'react';

function Quote() {

  const [quote, setQuote] = useState("");
  const [author, setAuthor] = useState("");

  function fetchQuote(){
    fetch("http://api.quotable.io/random")
      .then(res => res.json())
      .then((quote) => {
          setQuote(quote.content);  
          setAuthor(quote.author);
        }
      )
  }
  return (
    <div className="App">
         <div className="quote">
            <h2>{quote}</h2>
            <small>{author}</small>
         </div>
         <button className="btn" onClick={fetchQuote}>New Quote</button>
    </div>
  );
}

export default Quote;