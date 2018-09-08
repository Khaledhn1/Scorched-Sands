using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveManager : MonoBehaviour {
    public GameObject locationObjective;
    public GameObject killObjctive;
    int nextObj;
    ScoreCounter scoreCounter;
    KillObjctive killObj;
    private GameObject[]locSpawnPoint;
	GameObject loc;
	public Text text;
	public Text objDone;
    public int ObjectivesComplete;
	int type;
	GameObject kill;
	bool firstrun = true;

	// Use this for initialization
	void Start () {
        scoreCounter = (ScoreCounter)FindObjectOfType(typeof(ScoreCounter));
        locSpawnPoint = GameObject.FindGameObjectsWithTag("ObjectiveSpawnPoint");
        setObj();
    }
	
	// Update is called once per frame
	void Update () {
        LocationObjective locObj = (LocationObjective)FindObjectOfType(typeof(LocationObjective));
        killObj = (KillObjctive)FindObjectOfType(typeof(KillObjctive));
        if(locObj == null && killObj == null)
        {
            setObj();
        }
		if (type == 1) text.text = ("GO TO:"+loc.transform.position+" or just the big white tower :)");
		else {
		KillObjctive mykill = kill.GetComponent<KillObjctive>();
		text.text = ("0/" + mykill.requiredScore+" Kills");
		
		}
		objDone.text = (ObjectivesComplete+" Objectives Complete");
    }
    void setObj()
    {
        nextObj = Random.Range(0, 2);
        if (nextObj == 0)
        {
            int spawnPointIndex = Random.Range(0, locSpawnPoint.Length);
            loc = Instantiate(locationObjective, locSpawnPoint[spawnPointIndex].transform.position, locSpawnPoint[spawnPointIndex].transform.rotation);
            print("New Loc Obj");
			
			type = 1;
        }
        if(nextObj == 1)
        {
            int spawnPointIndex = Random.Range(0, locSpawnPoint.Length);
            kill = Instantiate(killObjctive);
            scoreCounter.primaryGun.myTargets = 0;
            scoreCounter.secondaryGun.myTargets = 0;
            KillObjctive mykill = kill.GetComponent<KillObjctive>();
            mykill.requiredScore = Random.Range(5, 20);
            print("New Kill Obj: " + mykill.requiredScore);
			type = 0;
			
			
			
        }
        print(ObjectivesComplete);
		if (!firstrun){
        ObjectivesComplete += 1;
		}
		
		firstrun = false;
        if(ObjectivesComplete == 5)
        {
            //rewards here
        }
    }

}
