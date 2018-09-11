using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour {
	public GameObject MM;
	public GameObject Options_Menu;
	public GameObject DEV_MENU;
	public GameObject DEVBUTTON;

void Start(){
	if(Debug.isDebugBuild) DEVBUTTON.SetActive(true);
	else DEVBUTTON.SetActive(false);
	
}
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
		 DEV_MENU.SetActive(false);
	}
	//Enable Main menu
	public void MainMenu(){
		 MM.SetActive(true); 
		 Options_Menu.SetActive(false);		 
		 DEV_MENU.SetActive(false);
	}
	//Enables Dev Menu
	public void DevMenu(){
		 MM.SetActive(false); 
		 Options_Menu.SetActive(false);
		 DEV_MENU.SetActive(true);
	}
}
