using System.Collections;
using System.Collections.Generic;
using MLAgents;
using UnityEngine;

public class AirHockeyGoal : MonoBehaviour
{

    public GameObject goalTextUI;

    public Agent Agent;
    public float RewardOnGoal;

	// Use this for initialization
	void Start () {
		
	}

    void Awake()
    {
        if (goalTextUI) { goalTextUI.SetActive(false); }
    }

    // Update is called once per frame
    void Update () {
		
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "ball")
        {
            Agent.AddReward(RewardOnGoal);
            StartCoroutine(ShowGoalUI());
            Agent.Done();  //all agents need to be reset
        }
    }

    IEnumerator ShowGoalUI()
    {
        if (goalTextUI) goalTextUI.SetActive(true);
        yield return new WaitForSeconds(.25f);
        if (goalTextUI) goalTextUI.SetActive(false);
    }

}
