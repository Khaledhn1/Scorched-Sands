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
    public float distFromCar = 2f;
    public float requiredDist = 5f;
    float dist;
    // Use this for initialization
    void Start()
    {
        CarActive = false;
        carUserControl.enabled = false;
        carController.enabled = false;
        MyCamera.enabled = false;
        //make sure everything on the car is disabled
    }

	// Update is called once per frame
	void Update (){

        if(Input.GetKeyUp(KeyCode.E))
        {
            print(CarActive);
            if(!CarActive) ChangeChar(); else startPlayer();
            //if we press E switch from character to car and vice versa
        }
        dist = Vector3.Distance(Char.transform.position,gameObject.transform.position);
}
  void startPlayer(){
  togglePlayer();
  toggleCar();
        Char.transform.position = new Vector3(MyCar.transform.position.x -distFromCar,MyCar.transform.position.y + 1f,MyCar.transform.position.z);
        //spawns player next to car
  }
	void ChangeChar(){

		RaycastHit hitInfo;
        Ray r = new Ray(PlayerCam.transform.position, PlayerCam.transform.forward);

		if (Physics.Raycast(r, out hitInfo))
            {
            if (hitInfo.transform.CompareTag("Vehicle") && dist <= requiredDist)
                {
                    if (CarActive == false)
                    {
						Debug.Log("Disabled Char");
                        togglePlayer();
                        toggleCar();
                    }
                }
            }
        //disables character and enables car controls

	}
  void togglePlayer()
  {

      CharCC.enabled = !CharCC.enabled;
      CharFPC.enabled = !CharFPC.enabled;
      PlayerCam.enabled = !PlayerCam.enabled;
      Char.SetActive(CharCC.enabled);
  }
  void toggleCar()
  {

      MyCamera.enabled = !MyCamera.enabled;
      carUserControl.enabled = !carUserControl.enabled;
      carController.enabled = !carController.enabled;
      Char.SetActive(CharCC.enabled);
      CarActive = !CarActive;

  }
}
