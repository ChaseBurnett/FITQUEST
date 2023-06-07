import { useState } from "react";
import { getCurrentUser } from "../../Utils/Constants";
import {Form} from "reactstrap";
import { Button } from "reactstrap";
import { useNavigate } from "react-router-dom";


export const AddCheckInForm = () => {

    const currentUser = getCurrentUser();
    const navigate = useNavigate();
    
    const [newCheckIn, setNewCheckIn] = useState({
        date: "",
        userChallengesId: 0,
        successful: false
    })

    const handleInputChange = (event) => {
        event.preventDefault();

        const formToSend = {
            id: currentUser.id,
            date: newCheckIn.date,
            userChallengesId: newCheckIn.userChallengesId,
            successful: newCheckIn.successful
        } 

        const sendData = async () => {
            const response = await fetch("https://localhost:7214/api/ChallengeCheckIn", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(formToSend)
            });
            const data = await response.json();
            console.log(data);
            navigate("/");
        }
        sendData();

    }

    return (
        <>
        <Form>
            <div className="form-group">
                <label htmlFor="date">Date</label>
                <input type="date" className="form-control" id="date" placeholder="Enter date" onChange={(e) => setNewCheckIn({ ...newCheckIn, date: e.target.value })} />
            </div>
            <div className="form-group">
                <label htmlFor="userChallengesId">Challenge</label>
                <input type="number" className="form-control" id="userChallengesId" placeholder="Enter challenge ID" onChange={(e) => setNewCheckIn({ ...newCheckIn, userChallengesId: e.target.value })} />
            </div>
            <div className="form-group">
                <label htmlFor="successful">Successful</label>
                <input
                type="checkbox"
                className="form-control"
                id="successful"
                checked={newCheckIn.successful} 
                onChange={(e) =>
                setNewCheckIn({ ...newCheckIn, successful: e.target.checked })
                } />
            </div>
            <Button type="submit" className="btn btn-primary" onClick={handleInputChange}>Submit</Button>
            <Button type="reset" className="btn btn-primary">Reset</Button>
        </Form>
        </>
    )
}