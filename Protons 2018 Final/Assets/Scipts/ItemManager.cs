using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour {

	public GameObject ammo;
	public GameObject health;
	public float SpawnTime = 3f;
	GameObject he;
	GameObject am;
	private GameObject[] spawnPoints;
	// Use this for initialization
	void Start () {
		
		InvokeRepeating("Spawn", SpawnTime, SpawnTime);
		spawnPoints = GameObject.FindGameObjectsWithTag("ItemSpawnPoint");
	}
	
	// Update is called once per frame
	void Spawn() {
		int spawnPointIndex = Random.Range(0,spawnPoints.Length);
		int type = Random.Range(0,2);
		
	if (type == 0){
			he = Instantiate (health,spawnPoints[spawnPointIndex].transform.position,spawnPoints[spawnPointIndex].transform.rotation); 
			he.SetActive(true);
		}else{
			am = Instantiate (ammo,spawnPoints[spawnPointIndex].transform.position,spawnPoints[spawnPointIndex].transform.rotation); 
			am.SetActive(true);
		}
	}
} 
