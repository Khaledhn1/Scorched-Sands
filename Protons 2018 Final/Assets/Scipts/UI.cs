using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {

	public GameObject[] guns;
	GameObject guna;
	public Gun gun1;
	public Gun gun2;
	public Target player;
	public Text CurrentAmmo;
	public Text MaxAmmo;
	public Animator playerAnim;
	public Slider health;
	// Use this for initialization
	void Start () {
		guna = guns[0];
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
