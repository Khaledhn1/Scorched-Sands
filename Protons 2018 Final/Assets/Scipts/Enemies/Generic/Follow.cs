using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {

	public Transform player;
	public Target PlayerHealth;
	public Animator anim;
	public float speed = 3f;
	void Start () {
		
	}
	
	void Update () {
 
        if 
		(Vector3.Distance(transform.position, player.position) > 1f)
		{
			anim.Play("run");
			
        }
		else anim.Play("idle");
 
    }
	void LateUpdate(){
		 transform.Rotate(new Vector3(0, 0, 0), Space.Self);
		 transform.LookAt(player.position);
		 if
		(Vector3.Distance(transform.position, player.position) > 1f)
		{
			
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
		}
	}
}

