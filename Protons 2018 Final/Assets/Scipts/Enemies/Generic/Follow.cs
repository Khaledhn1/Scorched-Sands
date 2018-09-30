using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {

	public Transform player;
	public Target PlayerHealth;
    private Animator anim;
	public float speed = 3f;
	void Start () {
        anim = GetComponent<Animator>();
    }
	
	void Update () {
 

			anim.Play("Run");
		
 
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

