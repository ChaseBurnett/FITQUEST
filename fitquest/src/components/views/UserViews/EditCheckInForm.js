import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { Form } from "reactstrap";
import { getCurrentUser } from "../../Utils/Constants";

export const EditCheckInForm = () => {

    const currentUser = getCurrentUser();
    const navigate = useNavigate();

    const [checkIn, updateCheckIn] = useState({
        date: "",
        userChallengesId: 0,
        successful: false
    })

    const handleInputChange = (event) => {

        const formToSend = {
            id: currentUser.id,
            date: checkIn.date,
            userChallengesId: checkIn.userChallengesId,
            successful: checkIn.successful
        } 

        const sendData = async () => {
            const response = await fetch("https://localhost:7214/api/ChallengeCheckIn", {
                method: "PUT",
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
                <input type="date" className="form-control" id="date" placeholder="Enter date" onChange={(e) => updateCheckIn({ ...checkIn, date: e.target.value })} />
            </div>
            <div className="form-group">
                <label htmlFor="userChallengesId">Challenge</label>
                <input type="number" className="form-control" id="userChallengesId" placeholder="Enter challenge ID" onChange={(e) => updateCheckIn({ ...checkIn, userChallengesId: e.target.value })} />
            </div>
            <div className="form-group">
                <label htmlFor="successful">Successful</label>
                <input type="checkbox" className="form-control" id="successful" checked={checkIn.successful} onChange={(e) => updateCheckIn({ ...checkIn, successful: e.target.checked })} />
            </div>
            <button type="submit" className="btn btn-primary" onClick={handleInputChange}>Submit Edit</button>
            <button type="submit" className="btn btn-primary" onClick={() => navigate("/")}>Cancel</button>
        </Form>
        </>
    )
}
