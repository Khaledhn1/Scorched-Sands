using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour {
    int counter = 0;
    public WeaponHolder weaponHolder;
    Gun activeGun;

    void Start()
    {
        weaponHolder = GetComponent<WeaponHolder>();
    }
    void Update()
    {
        if (weaponHolder.PrimaryGun.activeInHierarchy)
        {
            activeGun = weaponHolder.PrimaryGun.GetComponent<Gun>();
        }
        else
        {
            activeGun = weaponHolder.SecondaryGun.GetComponent<Gun>();
        }
        if(activeGun.myTarget != null)
        {
            if(activeGun.myTarget.isDestroyed == true)
            {
                counter += 1;
                print(counter);
            }
        }
    }      
}
