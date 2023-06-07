import { useNavigate } from "react-router-dom";
import { authsignOut } from "../../Utils/authUtils";
import { useState,useEffect } from "react";
import { CardBody, CardTitle, Container, List, ListGroup, ListGroupItem, Modal } from "reactstrap";
import { getCurrentUser } from "../../Utils/Constants";
import { Card } from "reactstrap";
import { DARK_GRAY, BLACK, WHITE, DIRTY_WHITE, SLATE, LIGHT_GRAY } from "../../Utils/Constants";


const userUrl = "https://localhost:7214/api/User/";
const challengeCheckinUrl = "https://localhost:7214/api/ChallengeCheckIn/USER/";
const challengeT1Url = "https://localhost:7214/api/Challenge/1";
const challengeT2Url = "https://localhost:7214/api/Challenge/2";
const challengeT3Url = "https://localhost:7214/api/Challenge/3";



export const HomeView = () => {

    let navigate = useNavigate();

    const currentUser = getCurrentUser();
    const [user, setUser] = useState([]);
    const [tier1, setTier1] = useState([]);
    const [tier2, setTier2] = useState([]);
    const [tier3, setTier3] = useState([]);
    const [challengeCheckIns, setchallengeCheckIns] = useState([]);

    const fetchUserDetails = async () => {
        const fetchData = await fetch(`${userUrl}${currentUser.id}`);
        const data = await fetchData.json();
        setUser(data)
    };
      

    const fetchChallengeCheckIns = async () => {
        const fetchData = await fetch(`${challengeCheckinUrl}${currentUser.id}`);
        const data = await fetchData.json();
        setchallengeCheckIns(data) 
    };

    const fetchTier1 = async () => {
        const fetchData = await fetch(`${challengeT1Url}`);
        const data = await fetchData.json();
        setTier1(data)
    };

    const fetchTier2 = async () => {
        const fetchData = await fetch(`${challengeT2Url}`);
        const data = await fetchData.json();
        setTier2(data)
    };

    const fetchTier3 = async () => {
        const fetchData = await fetch(`${challengeT3Url}`);
        const data = await fetchData.json();
        setTier3(data)
    };



    useEffect(() => {fetchUserDetails()},[]);
    useEffect(() => {fetchChallengeCheckIns()},[]);
    useEffect(() => {fetchTier1()},[]);
    useEffect(() => {fetchTier2()},[]);
    useEffect(() => {fetchTier3()},[]);




    return(
    <>
        <main>
        <Container>
        <div>
            <h1>FITQUEST</h1>
            <h2>Welcome {user.userName}!</h2>
            <button type="submit" onClick={() => authsignOut(navigate)}>Log Out</button>
            <button type="submit" onClick={() => navigate("/addCheckIn")}>Add Check In</button>
        </div>

        <div className="d-flex justify-content-center" 
             style={{margin:`20px 0`}}>
        <Card style={{color: `${WHITE}`, 
        backgroundColor: `${SLATE}`,
        border: `5px solid ${LIGHT_GRAY}`,
        padding: '15px',
        margin: '5px'}}>
        <h2>Previous Check In's</h2>
        {Array.isArray(challengeCheckIns) ? (
            challengeCheckIns.map((checkIn) => (
            <>
                <h3>{checkIn.title}</h3>
                <h4>{checkIn.date}</h4>
                <h4>{checkIn.successful ? "True" : "False"}</h4>
            </>
            ))
        ) : (
            <p>No challenge check-ins available.</p>
        )}
        </Card>
        </div>

        <ListGroup style={{color: `${WHITE}`, 
        backgroundColor: `${LIGHT_GRAY}`,
        border: `5px solid ${SLATE}`,
        padding: '15px',
        margin: '5px'}}>
        <h3><b>Tier 1 Challenges</b></h3>
        {Array.isArray(tier1) ? (
            tier1.map((challenge) => (
            <>
                <h3>{challenge.title}</h3>
                <h4>{challenge.description}</h4>
                </>
            ))
        ) : (
            <p>No challenges available.</p>
        )}
        </ListGroup>

        <ListGroup style={{color: `${WHITE}`, 
        backgroundColor: `${LIGHT_GRAY}`,
        border: `5px solid ${SLATE}`,
        padding: '15px',
        margin: '5px'}}>
        <h3>Tier 2 Challenges</h3>
        {Array.isArray(tier2) ? (
            tier2.map((challenge) => (
            <>
                <ListGroupItem>
                <h3>{challenge.title}</h3>
                <h4>{challenge.description}</h4>
                </ListGroupItem>
                </>
            ))
        ) : (
            <p>No challenges available.</p>
        )}
        </ListGroup>
        
        <ListGroup style={{color: `${WHITE}`, 
        backgroundColor: `${LIGHT_GRAY}`,
        border: `5px solid ${SLATE}`,
        padding: '15px',
        margin: '5px'}}>
        <h3>Tier 3 Challenges</h3>
        {Array.isArray(tier3) ? (
            tier3.map((challenge) => (
            <>
                <ListGroupItem>
                <h3>{challenge.title}</h3>
                <h4>{challenge.description}</h4>
                </ListGroupItem>
                </>
            ))
        ) : (
            <p>No challenges available.</p>
        )}
        </ListGroup>
        </Container>
        </main>
        </>
        )
};
