using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class Pause : MonoBehaviour {

	//public GameObject gun;
	public static bool isPaused;
	public GameObject pausemenu;
	public FirstPersonController mouseLook;
	public Gun gun;


    void Start () {
		isPaused = false;
        //exit = false;
        pausemenu.SetActive(false);
    }

	// Update is called once per frame
	void Update () {
		if (isPaused) {
			pauseGame (true);
			mouseLook.enabled = false;
			gun.enabled = false;
			Cursor.visible = true;
		} else {
			pauseGame (false);
			mouseLook.enabled = true;
			gun.enabled = true;
			Cursor.visible = false;
		}

		if (Input.GetButtonDown ("Cancel")) {
			switchPause ();

		}
	}
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
	public void switchPause(){
		if (isPaused) {
			isPaused = false;
		} else {
			isPaused = true;
		}
	}

}