using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehavior : MonoBehaviour {

	private Wander wander;
	private Follow follow;
	public bool playerInSight;
	public Transform player;
	public Target playerHealth;
	private Animator anim;
	private Gun gun;

	// Use this for initialization
	void Start () {
		wander = gameObject.GetComponent<Wander>();
		follow = gameObject.GetComponent<Follow>();		
		anim = gameObject.GetComponentInChildren<Animator>();
		//playerHealth = player.GetComponent<Target>();

		playerInSight = false;
	
		wander.enabled = true;
		follow.enabled = false;

		StartCoroutine(genericBehaviour());
	}
	void Update(){
		if(playerInSight){
			float dist = Vector3.Distance(player.position, gameObject.transform.position);
			if(dist < 1.5)StartCoroutine(MeleeAttack());
		}
		if(wander.enabled) anim.Play("Walk");
	}
	IEnumerator MeleeAttack(){
		while(true){
			//play animation
			anim.Play("Attack");
			playerHealth.health -= 15;
			anim.Play("Walk");
			yield return new WaitForSeconds(4);
			
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
