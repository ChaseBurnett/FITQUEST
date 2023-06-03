import {Route,Routes} from "react-router-dom";
import {ApplicationViews} from "./views/ApplicationViews";
import { Login } from "./views/LoginView/Login";
import { Register } from "./views/LoginView/Register";


export const FitQuest = () => {
    return (
        <Routes>
        <Route path="/login" element={<Login/>} />
        <Route path="/register" element={<Register/>} />
 
        <Route
            path="*"
            element={

                <ApplicationViews />
            }
        
        />
        </Routes>
    );
};