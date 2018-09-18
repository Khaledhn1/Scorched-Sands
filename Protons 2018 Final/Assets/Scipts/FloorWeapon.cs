using UnityEngine;

public class FloorWeapon : MonoBehaviour {

    public GameObject playerCamera;
    public WeaponHolder weaponHolder;
    FloorWeapon myself;
    public Gun mygun;
    FloorWeapon floorWeapon;
    Transform gunTransform;
    Vector3 myPosition;
    Camera myCamera;

    private void Start()
    {
        myself = GetComponent<FloorWeapon>();
        myCamera = GetComponentInChildren<Camera>();
        myPosition = transform.position;

    }
    // Update is called once per frame
    void Update()
    {
        RaycastHit hitInfo; 
        Ray r = new Ray(playerCamera.transform.position, playerCamera.transform.forward); 

        //if we hit something
        if (Input.GetKeyDown(KeyCode.E))
        {
            //if E pressed
            if (Physics.Raycast(r, out hitInfo))
            {
                   if (hitInfo.transform.CompareTag("Weapon"))
                    {
                    //if thing we hit is weapon
                    if (weaponHolder.CurrentWeapon == 1)
                    {
                        transform.parent = weaponHolder.PrimaryGun.transform.parent;
                        transform.position = weaponHolder.PrimaryGun.transform.position;
                        gunTransform = weaponHolder.PrimaryGun.transform;
                        gunTransform.parent = null;
                        gunTransform.position = myPosition;
                        Gun weaponGun = weaponHolder.PrimaryGun.GetComponent<Gun>();
                        Camera weaponCamera = weaponHolder.PrimaryGun.GetComponentInChildren<Camera>();
                        weaponCamera.enabled = false;
                        myCamera.enabled = true;
                        weaponGun.enabled = false;
                        mygun.enabled = true;
                        floorWeapon = weaponHolder.PrimaryGun.GetComponent<FloorWeapon>();
                        floorWeapon.enabled = true;
                        print(floorWeapon);
                        weaponHolder.PrimaryGun = gameObject;
                        myself.enabled = !myself.enabled;
                    }
                    if (weaponHolder.CurrentWeapon == 2)
                    {
                        transform.parent = weaponHolder.SecondaryGun.transform.parent;
                        transform.position = weaponHolder.SecondaryGun.transform.position;
                        gunTransform = weaponHolder.SecondaryGun.transform;
                        gunTransform.parent = null;
                        gunTransform.position = myPosition;
                        Gun weaponGun = weaponHolder.SecondaryGun.GetComponent<Gun>();
                        Camera weaponCamera = weaponHolder.PrimaryGun.GetComponentInChildren<Camera>();
                        weaponCamera.enabled = false;
                        myCamera.enabled = false;
                        weaponGun.enabled = false;
                        mygun.enabled = true;
                        floorWeapon = weaponHolder.SecondaryGun.GetComponent<FloorWeapon>();
                        floorWeapon.enabled = true;
                        weaponHolder.SecondaryGun = gameObject;
                        myself.enabled = !myself.enabled;
                    }
                }
                //instantiate a new weapon instead of one in your hand
            }
        }
    }
}
