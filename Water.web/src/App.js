import './App.css';
import Glasses from './components/glasses';

function App() {
  return (
    <div className="App">
        <h1>Number of glasses of water</h1>
        <h2>
        How many glasses of water did I drink today?
        </h2>
      <div>
        <Glasses />
        </div>
    </div>
  );
}

export default App;
