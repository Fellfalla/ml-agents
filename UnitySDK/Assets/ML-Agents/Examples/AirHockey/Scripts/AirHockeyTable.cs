using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerStateAirHockey
{
    public int playerIndex; 
    public Rigidbody agentRB; 
    public Vector3 startingPos; 
    public AgentAirHockey agentScript; 
    public float ballPosReward;
}


public class AirHockeyTable : MonoBehaviour
{

    public List<PlayerStateAirHockey> playerStates = new List<PlayerStateAirHockey>();


    void Awake()
    {

    }
}
