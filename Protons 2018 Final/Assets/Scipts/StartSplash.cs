using UnityEngine;
using System.Collections;


public class StartSplash : MonoBehaviour {
	public float setTime = 3.0f;    //Duration before loading next level
	public float dimTime = 2.0f;  //Duration Before Staring to Fade or Dim Lights
	public Light dimLight;   //Main Light Source to Dim
	public float zoomSpeed = 0.2f;   //Speed at which camera zooms in
	public Camera c;
	float timer;     // Use this for initialization
	public GameObject game;

	void Start () {
		timer = 0.0f; //Initializes Timer to 0
	}

	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime; //Adds Time.deltaTime to timer each update
		c.fieldOfView -= zoomSpeed; //Zooms in Camera
		if (timer > dimTime && timer < setTime) {
			dimLight.intensity -= zoomSpeed; //Dims Lights
		} else if (timer > setTime) {
			game.SetActive(true);
			gameObject.SetActive(false);
		}
	}
}