using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillObjctive : MonoBehaviour {
    ScoreCounter scoreCounter;
    public int requiredScore;
    public bool isDone = false;
	void Start () {
        scoreCounter = (ScoreCounter)FindObjectOfType(typeof(ScoreCounter));
	}
	
	void Update () {
        if (scoreCounter.kills == requiredScore)
            //if we got the required amount of kills
        {
            EndObjective();
        }
	}
    void EndObjective()
    {
        print("Yay");
        isDone = true;
        Destroy(gameObject);
        //Destroy objective (See objective manager)
    }
}
