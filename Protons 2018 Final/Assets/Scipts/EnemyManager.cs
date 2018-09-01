using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

	public Target PlayerHealth;
	public GameObject Zombie;
	public GameObject Human;
	public float SpawnTime = 3f;
	GameObject zom;
	GameObject hum;
	private GameObject[] spawnPoints;
	public DayNightController time;
	// Use this for initialization
	void Start () {
		
		InvokeRepeating("Spawn", SpawnTime, SpawnTime);
		spawnPoints = GameObject.FindGameObjectsWithTag("EnemySpawnPoint");
	}
	
	// Update is called once per frame
	void Spawn() {
		if(PlayerHealth.health <=0) return;
		int spawnPointIndex = Random.Range(0,spawnPoints.Length);
		
	if (time.currentTime < 8.0f || time.currentTime > 21.0f){
			zom = Instantiate (Zombie,spawnPoints[spawnPointIndex].transform.position,spawnPoints[spawnPointIndex].transform.rotation); 
			zom.SetActive(true);
		}else{
			hum = Instantiate (Human,spawnPoints[spawnPointIndex].transform.position,spawnPoints[spawnPointIndex].transform.rotation); 
			hum.SetActive(true);
		}
	}
}
