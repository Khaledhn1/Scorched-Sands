using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoilController : MonoBehaviour {
	public Transform recoilMod;
	GameObject weapon;
	float maxRecoil_x = -20f;
	float recoilSpeed = 10f;
	float recoil = 0.0f;
	Quaternion original;
	public Gun gun;

	void Start()
	{
		original = weapon.transform.rotation;
		gun = GetComponent<Gun>();
	}
	void Update () {
		if(Input.GetButtonDown("Fire1"))
		{
			print("Recoiled");
			recoil += 0.01f;
		}
		recoiling();

	}
	void recoiling()
	{
		if(recoil > 0 && !gun.isReloading)
		{
			Transform myTransform = transform;
			myTransform.Rotate (Vector3.right, maxRecoil_x * recoilSpeed * Time.deltaTime);
			recoil -= Time.deltaTime;
		}
		else
		{
			Transform myTransform = transform;
			myTransform.Rotate(Vector3.right, original.x * recoilSpeed * Time.deltaTime);
			recoil = 0;
		}
	}
}
