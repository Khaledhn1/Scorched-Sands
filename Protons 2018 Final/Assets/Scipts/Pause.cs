﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class Pause : MonoBehaviour {

	//public GameObject gun;
	public static bool isPaused;
	public GameObject pausemenu;
	public FirstPersonController mouseLook;
	public GameObject gun;
	public GameObject htp;


    void Start () {
		isPaused = false;
        //exit = false;
        pausemenu.SetActive(false);
    }

	// Update is called once per frame
	void Update () {
		//Disable Player control
		if (isPaused) {
			pauseGame (true);
			mouseLook.enabled = false;
			gun.SetActive(false);
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.Confined;
		} //Enable Player control
		else {
			pauseGame (false);
			mouseLook.enabled = true;
			gun.SetActive(true);
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
		}
		//Enable and disable pause
		if (Input.GetButtonDown ("Cancel")) {
			switchPause ();

		}
	}
	//Stop all ingame calculations
	void pauseGame(bool state){
		if (state) {
			Time.timeScale = 0.0f;

			//gun.GetComponent<AudioSource> ().enabled = false;
		} else {
			Time.timeScale = 1.0f;
			pausemenu.SetActive (false);
			//gun.GetComponent<AudioSource> ().enabled = true;
		}
		pausemenu.SetActive (state);
	}
	//Switch between pause and unpause
	public void switchPause(){
		if (isPaused) {
			isPaused = false;
		} else {
			isPaused = true;
		}
	}
	//Exit
	public void mainmenu(){
		SceneManager.LoadScene(0);
	}
	//Reenable everything
	public void resume(){
		pausemenu.SetActive(false);
		isPaused = false;
		pauseGame (false);
		mouseLook.enabled = true;
		gun.SetActive(true);
		Cursor.visible = false;
	}
	//HOW TO PLAY
	public void htpON(){
		pausemenu.SetActive(false);
		htp.SetActive(true);
	}
	
	//HOW TO PLAY OFF
	public void htpOFF(){
		pausemenu.SetActive(true);
		htp.SetActive(false);
	}

}