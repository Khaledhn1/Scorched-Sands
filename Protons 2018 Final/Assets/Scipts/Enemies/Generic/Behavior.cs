using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behavior : MonoBehaviour {

	private Wander wander;
	private Follow follow;
	public bool playerInSight;
	// Use this for initialization
	void Start () {
		wander = gameObject.GetComponent<Wander>();
		follow = gameObject.GetComponent<Follow>();
		
		playerInSight = false;
		
		wander.enabled = true;
		follow.enabled = false;
		
		StartCoroutine(genericBehaviour());
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
