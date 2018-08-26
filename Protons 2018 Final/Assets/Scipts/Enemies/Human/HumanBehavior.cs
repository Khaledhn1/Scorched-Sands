using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanBehavior : MonoBehaviour {

	private Wander wander;
	private Follow follow;
	public bool playerInSight;
	public Transform player;
	public Target playerHealth;
	private Gun gun;

	// Use this for initialization
	void Start () {
		wander = gameObject.GetComponent<Wander>();
		follow = gameObject.GetComponent<Follow>();
		//playerHealth = player.GetComponent<Target>();

		playerInSight = false;

		wander.enabled = true;
		follow.enabled = false;

		StartCoroutine(genericBehaviour());
	}
	void Update(){
		if(playerInSight){
			float dist = Vector3.Distance(player.position, gameObject.transform.position);
			if (dist > 5 && dist < 30){
				RaycastHit hitInfo;
				Ray r = new Ray(gameObject.transform.position, gameObject.transform.forward);
				Debug.Log("Created Ray");
				if (Physics.Raycast(r, out hitInfo))
				{Debug.Log("Ray Hit Something");
					if (hitInfo.transform.CompareTag("Player"))
					{
						Debug.Log("It's a player!");
						playerHealth.health -= 20;
					}
				}				
			}else if(dist < 3){
				StartCoroutine(MeleeAttack());
			}
		}
	}
	IEnumerator MeleeAttack(){
		while(true){
			playerHealth.health -= 40;
			yield return new WaitForSeconds(2);
			//play animation
			
		}
		
	}
	IEnumerator genericBehaviour(){
		while(!playerInSight){
			RaycastHit hitInfo;
			Ray r = new Ray(gameObject.transform.position, gameObject.transform.forward);

			if (Physics.Raycast(r, out hitInfo))
			{
				if (hitInfo.transform.CompareTag("Player"))
				{
						switchBehavior();
						yield return new WaitForSeconds(5);
						switchBehavior();
				}
			}
			yield return null ;
		}
		
	}
	private void switchBehavior(){
		playerInSight = !playerInSight;
		wander.enabled = !wander.enabled;
		follow.enabled = !follow.enabled;
	}

}
