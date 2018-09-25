using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using MLAgents;


public class AgentAirHockey : Agent
{
    int playerIndex;
    public AirHockeyTable area;
    [HideInInspector]
    public Rigidbody agentRB;
    public float Acceleration = 10; // ms^-2

    public List<Rigidbody> ObservedRigidbodies;

    public override void InitializeAgent()
    {
        base.InitializeAgent();
        PlayerStateAirHockey playerState = new PlayerStateAirHockey();
        playerState.agentRB = GetComponent<Rigidbody>();
        agentRB = GetComponent<Rigidbody>();
        agentRB.maxAngularVelocity = 500;
        playerState.startingPos = transform.position;
        playerState.agentScript = this;
        area.playerStates.Add(playerState);
        playerIndex = area.playerStates.IndexOf(playerState);
        playerState.playerIndex = playerIndex;
    }

    public override void CollectObservations()
    {
        foreach (var r in ObservedRigidbodies)
        {
            // add absolute values
            AddVectorObs(r.position.x);
            AddVectorObs(r.position.y);
            AddVectorObs(r.velocity.x);
            AddVectorObs(r.velocity.y);

            // add relative values
            foreach (var otherR in ObservedRigidbodies)
            {
                if (r != otherR)
                {
                    AddVectorObs(otherR.position.x - r.position.x);
                    AddVectorObs(otherR.position.y - r.position.y);
                    AddVectorObs(otherR.velocity.x - r.velocity.x);
                    AddVectorObs(otherR.velocity.y - r.velocity.y);
                }
            }
        }
    }

    public void MoveAgent(float[] act)
    {
        Vector3 dirToGo = Vector3.zero;

        int action = Mathf.FloorToInt(act[0]);

        switch (action)
        {
            case 0:
                dirToGo = Vector3.zero;
                break;
            case 1:
                dirToGo = Vector3.forward * 1f;
                break;
            case 2:
                dirToGo = Vector3.forward * -1f;
                break;
            case 3:
                dirToGo = Vector3.right * 1f;
                break;
            case 4:
                dirToGo = Vector3.right * -1f;
                break;
        }

        agentRB.AddForce(dirToGo * Acceleration, ForceMode.Force);

    }


    public override void AgentAction(float[] vectorAction, string textAction)
    {
        AddReward(1f / 3000f);
        MoveAgent(vectorAction);
    }

    public override void AgentReset()
    {
        
        foreach (var spawnable in FindObjectsOfType<Spawnable>())
        {
            spawnable.Respawn();
        }

        agentRB.velocity = Vector3.zero;
        agentRB.angularVelocity = Vector3.zero;
    }

    public override void AgentOnDone()
    {

    }
}
