using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoilController : MonoBehaviour {
    public Camera myCamera;
    public float maxRecoil_x = -8f;
	float recoilSpeed = 10f;
    Gun currentgun;
    Quaternion recoilGoal ;

    private void Start()
    {
        currentgun = GetComponent<Gun>();

    }
    void Update () {
        recoilGoal = myCamera.transform.rotation * Quaternion.Euler(maxRecoil_x,0,0);
        Recoiling();
        
    }
    void Recoiling()
    {
        if (Input.GetButton("Fire1") && !currentgun.isReloading)
        {
            Transform myCameraTransform = myCamera.transform;
            myCameraTransform.rotation = Quaternion.Slerp(myCameraTransform.rotation, recoilGoal, Time.deltaTime * recoilSpeed);
            //rotates camera if we shoot
        }
    }
}