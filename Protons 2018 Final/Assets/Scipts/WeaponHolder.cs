using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour {
    public GameObject PrimaryGun, SecondaryGun;
    public int CurrentWeapon;

	// Use this for initialization
    void Start () {
        PrimaryGun.SetActive(true);
        SecondaryGun.SetActive(false);
        CurrentWeapon = 1;
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown("1"))
        {
            PrimaryGun.SetActive(true);
            SecondaryGun.SetActive(false);
            CurrentWeapon = 1;
        }
        if (Input.GetKeyDown("2"))
        {
            PrimaryGun.SetActive(false);
            SecondaryGun.SetActive(true);
            CurrentWeapon = 2;
        }
	}
}
