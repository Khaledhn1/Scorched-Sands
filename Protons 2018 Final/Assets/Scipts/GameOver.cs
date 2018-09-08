using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {
	public GameObject game;
	public Target player;
	public GameObject go;
	// Use this for initialization

	// Update is called once per frame
	void Update () {
		//If player is dead GAMEOVER
		if (player.health <= 0){
			game.SetActive(false);
			go.SetActive(true);
			Cursor.visible = true;			
            Cursor.lockState = CursorLockMode.Confined;
		}
	}
	//Back button
	public void BTMM(){
		SceneManager.LoadScene(0);
	}
}
