using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

	[Range(1,50)]
	public int amount;
	
	public Target PlayerHealth;
	public Gun m4;
	public Gun m16;
	public GameObject m4go;
	public GameObject m16go;
	// Use this for initialization

	void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag ("Ammo"))
        {
            Destroy(other.gameObject);
			if(m4go.active)m4.maxAmmo += amount;
			if(m16go.active)m16.maxAmmo += amount;
        }
		if (other.gameObject.CompareTag ("Health"))
        {
            Destroy(other.gameObject);
			PlayerHealth.health += amount;
        }
    }

}
