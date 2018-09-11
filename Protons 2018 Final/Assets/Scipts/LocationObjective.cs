using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationObjective : MonoBehaviour {
    GameObject player;
    public GameObject myLoc;
    float dist;
    public bool isDone = false;
    public int requiredDist = 1;

    private void Start()
    {
        player = GameObject.Find("Player");
    }
    void Update () {
        dist = Vector3.Distance(player.transform.position, myLoc.transform.position);
        //checks distance between player and objective
        if(dist<requiredDist)
        {
            EndObjective();
            //Ends objective if we are in the required distance
        }
	}
    void EndObjective()
    {
        print("yay");
        isDone = true;
        Destroy(gameObject);
        //Destroys beacon (see objective manager)
    }
}
