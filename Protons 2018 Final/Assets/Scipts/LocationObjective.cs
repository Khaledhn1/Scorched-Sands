using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationObjective : MonoBehaviour {
    public GameObject player;
    public GameObject myLoc;
    public float dist;
	void Update () {
        dist = Vector3.Distance(player.transform.position, myLoc.transform.position);
        if(dist<2)
        {
            EndObjective();
        }
	}
    void EndObjective()
    {
        print("yay");
    }
}
