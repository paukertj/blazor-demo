import logo from './logo.svg';
import useBlazor from './hooks/useBlazor';

import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';

function App() {
  return (
    <div className="container">
    <div className="App row">
      <div className="App-header col">
        <img src={logo} className="App-logo" alt="logo" />
      </div>
      {useBlazor()}
      <div id="app" className="App-header col">Loading...</div>
    </div>
    </div>
  );
}

export default App;