import React from "react";
import { BrowserRouter } from "react-router-dom";
import "./App.css";
import MainRouter from "./Router/MainRouter";

function App() {
  return (
    <React.Fragment>
      <BrowserRouter>
        <MainRouter />
      </BrowserRouter>
    </React.Fragment>
  );
}

export default App;
