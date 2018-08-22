using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPhysics : MonoBehaviour {

	float waterLevel;
	private bool isUnderWater = false;
	private Color normalColor;
	private Color underwaterColor;
	ConstantForce constantForce;

	void Start()
	{
		normalColor = new Color(0.5f,0.5f,0.5f,0.5f);
		underwaterColor = new Color(0.22f,0.65f,0.77f,0.5f);
		constantForce = GetComponent<ConstantForce>();
	}
	void Update()
	{
		if(isUnderWater && Input.GetButtonDown("Q"))
		{
			constantForce.relativeForce = new Vector3(0,200,0);
		}
		else
		{
			constantForce.relativeForce = new Vector3(0,0,0);
		}
		if(isUnderWater && Input.GetButtonDown("E"))
		{
			constantForce.relativeForce = new Vector3(0,-200,0);
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
