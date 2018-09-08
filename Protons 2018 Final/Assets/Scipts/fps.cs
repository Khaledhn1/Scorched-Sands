using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fps : MonoBehaviour {
	
	public GameObject fpsCounter;
	private bool ison;
	// Use this for initialization
	void Start () {
		fpsCounter.SetActive(false);
		ison = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetButtonDown("FPS")){
			//ENABLE
			if (ison){
				fpsCounter.SetActive(false);
				ison = false;
				//DISABLE
			}else{
				fpsCounter.SetActive(true);
				ison = true;
		
			}
		}
	}
}
