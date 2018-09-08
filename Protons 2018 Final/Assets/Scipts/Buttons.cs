using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour {
	public GameObject MM;
	public GameObject Options_Menu;

	public void Play(){
		Application.LoadLevel(1);
	}
	public void Exit(){
		if (Application.isEditor){
			print("cant quit editor m8!");
		}else{
			Application.Quit();
		}
	}
	//enable options menu
	public void Options(){
		 MM.SetActive(false); 
		 Options_Menu.SetActive(true);
	}
	//Enable Main menu
	public void MainMenu(){
		 MM.SetActive(true); 
		 Options_Menu.SetActive(false);
	}
}
