import { useNavigate } from "react-router-dom";
import { authsignOut } from "../auth/authUtils";
import { useState,useEffect } from "react";


export const HomeView = () => {

    let navigate = useNavigate();

    return(
    <>
        <div>
            <h1>Welcome to the User Profile Page!</h1>
            <button type="submit" onClick={() => authsignOut}>Log Out</button>
        </div>
        </>
        )
};
