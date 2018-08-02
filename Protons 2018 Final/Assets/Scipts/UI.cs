using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {

	public Gun1 gun;
	public Target player;
	public Text CurrentAmmo;
	public Text MaxAmmo;
	public Slider health;
	// Use this for initialization
	void Start () {
		health.value = player.health;
		CurrentAmmo.text = gun.currentAmmo.ToString();
		MaxAmmo.text = gun.maxAmmo.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		health.value = player.health;
		CurrentAmmo.text = gun.currentAmmo.ToString();
		MaxAmmo.text = gun.maxAmmo.ToString();
	}
}
