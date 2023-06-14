import { Route, Routes } from "react-router-dom";
import { HomeView } from "./UserViews/HomeView";
import { AddCheckInForm } from "./UserViews/AddCheckInForm";
import { EditCheckInForm } from "./UserViews/EditCheckInForm";
import { Leaderboard } from "./UserViews/Leaderboard";

export const ApplicationViews = () => {

    return (
      <Routes>
        <Route path="/" element={<HomeView/>} />
        <Route path="/addCheckIn" element={<AddCheckInForm/>} />
        <Route path="/editCheckIn/:checkInId" element={<EditCheckInForm/>} />
        <Route path="/leaderboard" element={<Leaderboard/>} />
        
      
      </Routes>
    );
}