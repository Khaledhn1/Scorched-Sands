using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoilController : MonoBehaviour {
	GameObject weapon;
    public Camera myCamera;
	float maxRecoil_x = -10f;
	float recoilSpeed = 10f;
	float recoil = 0.0f;
    Gun currentgun;

    private void Start()
    {
        currentgun = GetComponent<Gun>();

    }
    void Update () {
        Recoiling();
        if (Input.GetButton("Fire1"))
		{
			recoil += 0.01f;

        }


    }
    void Recoiling()
	{
        if (recoil > 0 && !currentgun.isReloading)
        {
            Transform myCameraTransform = myCamera.transform;
            myCameraTransform.Rotate(Vector3.right* maxRecoil_x * recoilSpeed * Time.deltaTime);
            recoil -= Time.deltaTime;
        }
	}
}