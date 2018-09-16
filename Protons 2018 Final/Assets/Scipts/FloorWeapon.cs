using UnityEngine;

public class FloorWeapon : MonoBehaviour {

    public GameObject playerCamera;
    public WeaponHolder weaponHolder;
    FloorWeapon myself;
    public Gun mygun;
    FloorWeapon floorWeapon;

    private void Start()
    {
        myself = GetComponent<FloorWeapon>();
        floorWeapon = weaponHolder.PrimaryGun.GetComponent<FloorWeapon>();

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
                        Transform mytransform = transform;
                        transform.parent = weaponHolder.PrimaryGun.transform.parent;
                        transform.position = weaponHolder.PrimaryGun.transform.position;
                        weaponHolder.PrimaryGun.transform.parent = null;
                        weaponHolder.PrimaryGun.transform.position = mytransform.position;
                        Gun weaponGun = weaponHolder.PrimaryGun.GetComponent<Gun>();
                        weaponGun.enabled = false;
                        mygun.enabled = true;
                        floorWeapon.enabled = false;
                        weaponHolder.PrimaryGun = gameObject;
                        myself.enabled = !myself.enabled;
                    }
                }
                //instantiate a new weapon instead of one in your hand
            }
        }
    }
}
