using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour {
    public int kills;
    public WeaponHolder weaponHolder;
    void Update () {
        Gun primaryGun = weaponHolder.PrimaryGun.GetComponent<Gun>();
        Gun secondaryGun = weaponHolder.SecondaryGun.GetComponent<Gun>();
        kills = primaryGun.myTargets + secondaryGun.myTargets;
        if(primaryGun.isShooting)
        {
            print(kills);
        }
        if(secondaryGun.isShooting)
        {
            print(kills);
        }
	}
}
