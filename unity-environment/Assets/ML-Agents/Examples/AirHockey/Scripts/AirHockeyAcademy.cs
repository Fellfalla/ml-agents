using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;

public class AirHockeyAcademy : Academy
{

    public Brain brainStriker;
    //public Brain brainOpponent;

    public float gravityMultiplier = 1;
    public int maxAgentSteps;

    public float looseReward = 1; //if opponents score, goalie gets this neg reward (-1)
    public float winReward = -1; //if team scores, goalie gets this reward (currently 0...no reward. can play with this later)


    void Start()
    {
        Physics.gravity *= gravityMultiplier; //for soccer a multiplier of 3 looks good
    }

    public override void AcademyReset()
    {

    }

    public override void AcademyStep()
    {

    }

}
