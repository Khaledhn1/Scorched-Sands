using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillObjctive : MonoBehaviour {
    ScoreCounter scoreCounter;
    public int score;
	void Start () {
        scoreCounter = (ScoreCounter)FindObjectOfType(typeof(ScoreCounter));
	}
	
	void Update () {
        if (scoreCounter.kills == score)
        {
            EndObjective();
        }
	}
    void EndObjective()
    {
        print("Yay");
    }
}
