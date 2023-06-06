import { Route, Routes } from "react-router-dom";
import { HomeView } from "./UserViews/HomeView";

export const ApplicationViews = () => {

    return (
      <Routes>
        <Route path="/" element={<HomeView/>} />
        
      
      </Routes>
    );
}