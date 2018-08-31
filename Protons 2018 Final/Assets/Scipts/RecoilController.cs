using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoilController : MonoBehaviour {
	public Transform recoilMod;
	GameObject weapon;
    public Camera myCamera;
	float maxRecoil_x = -20f;
	float recoilSpeed = 10f;
	float recoil = 0.0f;
    public WeaponHolder weaponHolder;
    Gun activeGun;


	void Start()
	{
        weaponHolder = GetComponent<WeaponHolder>();

	}
	void Update () {
		if(Input.GetButtonDown("Fire1"))
		{
			recoil += 0.08f;

        }
        recoiling();

	}
	void recoiling()
	{
        if (recoil > 0)
        {
            Transform myCameraTransform = myCamera.transform;
            myCameraTransform.Rotate(Vector3.right, maxRecoil_x * recoilSpeed * Time.deltaTime);
            recoil -= Time.deltaTime;
            print("recoil");
            print(myCameraTransform.rotation);
        }
	}
}