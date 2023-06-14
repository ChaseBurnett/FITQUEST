
import React, { useState, useEffect } from "react";
import { Modal, ModalBody, ModalFooter, ModalHeader, Button } from "reactstrap";

const leaderboardUrl = "https://localhost:7214/api/Leaderboard";

export const Leaderboard = (props) => {
  const [modal, setModal] = useState(false);
  const toggle = () => setModal(!modal);

  const [leaderboard, setLeaderboard] = useState([]);

  const fetchLeaderboard = async () => {
    const fetchData = await fetch(leaderboardUrl);
    const data = await fetchData.json();
    setLeaderboard(data);
  };

  useEffect(() => {
    fetchLeaderboard();
  }, []);

  return (
    <div>
      <Button color="danger" onClick={toggle}>
        Leaderboard
      </Button>
      <Modal isOpen={modal} toggle={toggle} {...props}>
        <ModalHeader toggle={toggle}>Leaderboard</ModalHeader>
        <ModalBody>
          {leaderboard.map((leader) => (
            <React.Fragment key={leader.id}>
              <h3>{leader.userName}</h3>
              <h4>{leader.title}</h4>
              <h4>{leader.checkIns}</h4>
              <h4>{leader.successful}</h4>
            </React.Fragment>
          ))}
        </ModalBody>
        <ModalFooter>
          <Button color="secondary" onClick={toggle}>
            Exit
          </Button>
        </ModalFooter>
      </Modal>
    </div>
  );
};
