using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoilController : MonoBehaviour {
	GameObject weapon;
    public Camera myCamera;
	public float maxRecoil_x = -10f;
	float recoilSpeed = 10f;
    Gun currentgun;

    private void Start()
    {
        currentgun = GetComponent<Gun>();

    }
    void Update () {
        if (Input.GetButton("Fire1") && !currentgun.isReloading)
		{
            Transform myCameraTransform = myCamera.transform;
            myCameraTransform.Rotate(Vector3.right * maxRecoil_x * recoilSpeed * Time.deltaTime);
            //rotates camera if we shoot
        }


    }
}