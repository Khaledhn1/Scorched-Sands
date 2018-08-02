using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainRandomiser : MonoBehaviour {
	public GameObject music;
	public GameObject rain;
	public bool raining;

	void Update () {
		//raining = (Random.value > 0.5f);
		if (raining == true) {
			music.SetActive(false);
			rain.SetActive(true);
		}
		else{
			music.SetActive(true);
			rain.SetActive(false);
		}
	}
}
