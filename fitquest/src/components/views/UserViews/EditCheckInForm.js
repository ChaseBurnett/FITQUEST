import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { Form } from "reactstrap";
import { getCurrentUser } from "../../Utils/Constants";

export const EditCheckInForm = () => {
  const currentUser = getCurrentUser();
  const navigate = useNavigate();
  const { checkInId } = useParams();

  const [checkIn, setCheckIn] = useState({
    date: "",
    userChallengesId: "",
    successful: false,
  });

  useEffect(() => {
    const getCheckIn = async () => {
      const response = await fetch(
        `https://localhost:7214/api/ChallengeCheckIn/${checkInId}`
      );
      const data = await response.json();
      setCheckIn(data);
      console.log(data);
    };
    getCheckIn(checkInId);
    console.log(checkIn);
  }, [checkInId]);

  const handleInputChange = (event) => {
    event.preventDefault();

    const formToSend = {
      id: currentUser.id,
      date: checkIn.date,
      userChallengesId: checkIn.userChallengesId,
      successful: checkIn.successful,
    };

    const sendData = async () => {
      await fetch(`https://localhost:7214/api/ChallengeCheckIn/${checkInId}`, {
        method: "PUT",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(formToSend),
      });
      navigate("/");
    };
    sendData();
  };

  return (
    <>
      <Form>
        <div className="form-group">
          <label htmlFor="date">Date</label>
          <input
            type="date"
            className="form-control"
            id="date"
            placeholder="Enter date"
            value={checkIn.date ? checkIn.date.substring(0, 10) : ""}
            onChange={(e) => {
                const copy = { ...checkIn };
                copy.date = e.target.value;
                setCheckIn(copy);
            }}
            />
        </div>
        <div className="form-group">
          <label htmlFor="userChallengesId">Challenge</label>
          <input
            type="number"
            className="form-control"
            id="userChallengesId"
            placeholder="Enter challenge ID"
            value={checkIn.userChallengesId}
            onChange={(e) =>
              setCheckIn({ ...checkIn, userChallengesId: e.target.value })
            }
          />
        </div>
        <div className="form-group">
          <label htmlFor="successful">Successful</label>
          <input
            type="checkbox"
            className="form-control"
            id="successful"
            checked={checkIn.successful}
            onChange={(e) =>
              setCheckIn({ ...checkIn, successful: e.target.checked })
            }
          />
        </div>
        <button
          type="submit"
          className="btn btn-primary"
          onClick={handleInputChange}
        >
          Submit Edit
        </button>
        <button
          type="button"
          className="btn btn-primary"
          onClick={() => navigate("/")}
        >
          Cancel
        </button>
      </Form>
    </>
  );
};
