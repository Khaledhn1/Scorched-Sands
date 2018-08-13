using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;
using UnityStandardAssets.Characters.FirstPerson;

public class GetInCar : MonoBehaviour {
    public bool CarActive = false;
    public Camera MyCamera;
    public FirstPersonController CharFPC;
    public CharacterController CharCC;
    public GameObject MyCar;
    public CarUserControl carUserControl;
    public CarController carController;
    public Camera PlayerCam;
	public GameObject Char;
    // Use this for initialization
    void Start()
    {
        CarActive = false;
        carUserControl.enabled = false;
        carController.enabled = false;
        MyCamera.enabled = false;

    }
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKey(KeyCode.E))
        {
			if(CarActive == false){
				ChangeChar(); 
			}
			else if (CarActive == true)
            {
                CarActive = false;
                Debug.Log("Enabled Char");
                carUserControl.enabled = false;
                carController.enabled = false;
                CharFPC.enabled = true;
                CharCC.enabled = true;
                PlayerCam.enabled = true;
				MyCamera.enabled = false;
				Char.SetActive(true);
                Char.transform.position = new Vector3(MyCar.transform.position.x + 6f,MyCar.transform.position.y,MyCar.transform.position.z);
            }
		}
		
	}
	void ChangeChar(){
		
		RaycastHit hitInfo; 
        Ray r = new Ray(PlayerCam.transform.position, PlayerCam.transform.forward); 

		if (Physics.Raycast(r, out hitInfo))
            {
                if (hitInfo.transform.CompareTag("Vehicle"))
                {
                    if (CarActive == false)
                    {
						Debug.Log("Disabled Char");
                        CarActive = true;
                        CharFPC.enabled = false;
                        CharCC.enabled = false;
                        carUserControl.enabled = true;
                        carController.enabled = true;
                        MyCamera.enabled = true;
                        
                        PlayerCam.enabled = false;
						Char.SetActive(false);
                    }
                }
            }
            
	}
}
