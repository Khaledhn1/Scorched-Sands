using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour {
    public GameObject PrimaryGun, SecondaryGun;

	// Use this for initialization
    void Start () {
        PrimaryGun.SetActive(true);
        SecondaryGun.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown("1"))
        {
            PrimaryGun.SetActive(true);
            SecondaryGun.SetActive(false);
        }
        if (Input.GetKeyDown("2"))
        {
            PrimaryGun.SetActive(false);
            SecondaryGun.SetActive(true);
        }
	}
}
