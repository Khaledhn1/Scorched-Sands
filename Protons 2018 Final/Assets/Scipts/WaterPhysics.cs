using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPhysics : MonoBehaviour {

	float waterLevel;
	private bool isUnderWater = false;
	private Color normalColor;
	private Color underwaterColor;

	void Start()
	{
		normalColor = new Color(0.5f,0.5f,0.5f,0.5f);
		underwaterColor = new Color(0.22f,0.65f,0.77f,0.5f);
	}
	void Update()
	{
		if(isUnderWater && Input.GetButtonDown("Q"))
		{
			transform.Translate (new Vector3 (0,2,0) * Time.deltaTime);
		}
	}

	void setNormal()
	{
		RenderSettings.fogColor = normalColor;
		RenderSettings.fogDensity = 0.002f;
	}
	void setUnderWater()
	{
		RenderSettings.fogColor = underwaterColor;
		RenderSettings.fogDensity = 0.03f;
	}
	void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.CompareTag("Water"))
		{
			setUnderWater();
			isUnderWater = true;
		}
	}
	void OnCollisionExit(Collision col)
	{
		if(col.gameObject.CompareTag("Water"))
		{
			setNormal();
			isUnderWater = false;
		}
	}
}
