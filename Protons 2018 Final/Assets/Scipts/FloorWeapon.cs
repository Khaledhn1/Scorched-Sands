using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorWeapon : MonoBehaviour {

    public GameObject playerCamera;
    public GameObject prefab;
    public GameObject primary;
    public GameObject secondary;
    public WeaponHolder weaponHolder;
    Transform gun;

	// Update is called once per frame
	void Update()
    {
        RaycastHit hitInfo; 
        Ray r = new Ray(playerCamera.transform.position, playerCamera.transform.forward); 

        //if we hit something
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(r, out hitInfo))
            {
            
                   if (hitInfo.transform.CompareTag("Weapon"))
                    {
                

                    
                        if(weaponHolder.CurrentWeapon == 1)
                        {
                            gun = primary.transform;
                        GameObject clone = Instantiate(prefab);
                        Destroy(primary);
                        print("destroyed");
                        clone.transform.parent = gun.transform.parent;
                        clone.transform.position = gun.transform.position;
                        clone.transform.rotation = gun.transform.rotation;
                            weaponHolder.PrimaryGun = clone;
                        }
                        if (weaponHolder.CurrentWeapon == 2)
                        {
                         gun = secondary.transform;
                        GameObject clone = Instantiate(prefab);
                        Destroy(secondary);
                        print("destroyed");
                        clone.transform.parent = gun.transform.parent;
                        clone.transform.position = gun.transform.position;
                        clone.transform.rotation =  new Quaternion (gun.transform.rotation.x,gun.transform.rotation.y,gun.transform.rotation.z,gun.transform.rotation.w);
						weaponHolder.SecondaryGun = clone;
						}
                }
            }
        }
    }
}
