using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

	[Range(1,50)]
	public int amount;
	
	public Target PlayerHealth;
	Gun primary;
	Gun secondary;
	GameObject PrimaryGO;
	GameObject SecondaryGO;
    public WeaponHolder weaponHolder;
    // Use this for initialization
    private void Update()
    {
        PrimaryGO = weaponHolder.PrimaryGun;
        SecondaryGO = weaponHolder.SecondaryGun;
        primary = PrimaryGO.GetComponent<Gun>();
        secondary = SecondaryGO.GetComponent<Gun>();
    }
    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag ("Ammo"))
        {
            Destroy(other.gameObject);
            if(PrimaryGO.activeInHierarchy)primary.maxAmmo += amount;
            if(SecondaryGO.activeInHierarchy)secondary.maxAmmo += amount;
            //adds to ammo in your gun if you pick it up
        }
		if (other.gameObject.CompareTag ("Health"))
        {
            Destroy(other.gameObject);
			PlayerHealth.health += amount;
            //adds to player health
        }
    }

}
