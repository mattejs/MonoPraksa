import logo from './question.png';
import './App.css';
import Time from './Time';
import NameForm from './NameForm';
import Header from './Header';
import Quote from './Quote';



function App(props) {
  return (
    <div className="App">      
      <header className="App-header">
        <Header />
        <NameForm message="Learning React"/>
        <Quote />        
        <Time />
        <img src={logo} className="App-logo" alt="logo" />        
      </header>
    </div>
  );
}

export default App;
