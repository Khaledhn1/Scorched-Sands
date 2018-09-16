using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {

	public GameObject[] guns;
	GameObject guna;
    GameObject gunb;
	public Gun gun1;
	public Gun gun2;
	public Target player;
	public Text CurrentAmmo;
	public Text MaxAmmo;
	public Animator playerAnim;
	public Slider health;
    public WeaponHolder weaponHolder;
	// Use this for initialization
	void Start () {
        guns[0] = weaponHolder.PrimaryGun;
        guns[1] = weaponHolder.SecondaryGun;
		guna = guns[0];
        gunb = guns[1];
        gun1 = guna.GetComponent<Gun>();
        gun2 = gunb.GetComponent<Gun>();
		//update health
		health.value = player.health;
		//Update ui depending on what weapon is active
		if (guna.activeSelf){
			CurrentAmmo.text = gun1.currentAmmo.ToString();
			MaxAmmo.text = gun1.maxAmmo.ToString();
		}
		else{
			CurrentAmmo.text = gun2.currentAmmo.ToString();
			MaxAmmo.text = gun2.maxAmmo.ToString();
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		guna = guns[0];
		health.value = player.health;
		//if m4 is active use it's ammo
		if (guna.activeSelf){
			CurrentAmmo.text = gun1.currentAmmo.ToString();
			MaxAmmo.text = gun1.maxAmmo.ToString();
			playerAnim.Play("Idle");
		}
		//if mg16 is active use it's ammo
		else{
			CurrentAmmo.text = gun2.currentAmmo.ToString();
			MaxAmmo.text = gun2.maxAmmo.ToString();
			
			playerAnim.Play("Pistol Idle");
		}
	}
}
