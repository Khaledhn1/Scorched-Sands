using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {

	public Transform player;
	public Target PlayerHealth;
	private Animator anim;
	public float speed = 3f;
	void Start () {
		anim = gameObject.GetComponentInChildren<Animator>();
	}
	
	void Update () {
        transform.LookAt(player.position);
        transform.Rotate(new Vector3(0, -90, 0), Space.Self);
 
        if 
		(Vector3.Distance(transform.position, player.position) > 1f)
		{
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
			anim.Play("run");
			
        }
		else anim.Play("idle");
 
    }
}

