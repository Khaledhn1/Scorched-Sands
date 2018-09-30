using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanBehavior : MonoBehaviour {

	private Wander wander;
	private Follow follow;
	public bool playerInSight;
	public Transform player;
	public ObjectiveManager obj;
	public Target playerHealth;	
    public ParticleSystem particleSystem;
	
	private Animator anim;
	
	private Gun gun;
	public AudioClip audioClip;
	private AudioSource shoot;
	
    private float nextTimeToFire = 0f;
    public float fireRate = 5f;
	

	// Use this for initialization
	void Start () {
		wander = gameObject.GetComponent<Wander>();
		follow = gameObject.GetComponent<Follow>();
		
		anim = gameObject.GetComponent<Animator>();
		shoot = gameObject.GetComponentInChildren<AudioSource>();
		//playerHealth = player.GetComponent<Target>();

		playerInSight = false;
        //anim.Play("Run");
        wander.enabled = true;
		follow.enabled = false;

		StartCoroutine(genericBehaviour());
	}
	void Update(){
		if(Time.time >= nextTimeToFire) {
			
		nextTimeToFire = Time.time + 1 / fireRate;
			if(playerInSight){
				float dist = Vector3.Distance(player.position, gameObject.transform.position);
				if (dist > 0 && dist < 50){
					RaycastHit hitInfo;
					Ray r = new Ray(gameObject.transform.position, gameObject.transform.forward);
					Debug.Log("Created Ray");
					if (Physics.Raycast(r, out hitInfo))
					{Debug.Log("Ray Hit Something");
						if (hitInfo.transform.CompareTag("Player"))
						{
							Debug.Log("It's a player!");
							
							particleSystem.Play();
							shoot.PlayOneShot(audioClip);
							playerHealth.health -= 20;
						}
					}	
				}
			}
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
						if(obj) switchBehavior();
						else {
							playerInSight = true;
							wander.enabled = false;
							follow.enabled = true;
						}
						
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
