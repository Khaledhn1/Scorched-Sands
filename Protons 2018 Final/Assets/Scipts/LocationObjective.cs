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
        print(player.gameObject.name);
    }
    void Update () {
        dist = Vector3.Distance(player.transform.position, myLoc.transform.position);
        if(dist<requiredDist)
        {
            EndObjective();
        }
	}
    void EndObjective()
    {
        print("yay");
        isDone = true;
        Destroy(gameObject);
    }
}
