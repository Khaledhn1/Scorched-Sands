using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{
    public bool isShooting;
    public float damage = 10f;
    public float range = 100f;
    public int maxAmmo = 100;
    public int currentAmmo;
    public float reloadTime = 1f;
    public bool isReloading = false;
    public Animator animator;
    private float nextTimeToFire = 0f;
    public float fireRate = 15f;
    public ParticleSystem particlesystem;
    public AudioSource audioSource;
    public AudioClip audioClip;
    public Camera fpsCam;
    public GameObject impactEffect;
    public int maxClip = 10;
    public bool targeted;
    public int myTargets;

    private void Start()
    {
        currentAmmo = maxClip;
    }

    // Update is called once per frame
    void Update()
    {

        if (isReloading)
        {
            return;
            //doesn't let us do anything if we are reloading
        }

        if ((currentAmmo <= 0 && maxAmmo >0) || (Input.GetButton("Reload")) && currentAmmo < maxClip)
        {
            StartCoroutine(Reload());
            return;
            //if we run out of ammo in our clip or we press R, we reload
        }

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && currentAmmo>0)
        {
            nextTimeToFire = Time.time + 1 / fireRate;
            Shoot();
            isShooting = true;
            //if we press mouse1 and we have ammo in our clip we shoot
        }
        else
        {
          isShooting = false;
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading..");

        animator.SetBool("Reloading", true);

        yield return new WaitForSeconds(reloadTime);

        animator.SetBool("Reloading", false);
		    maxAmmo = maxAmmo - maxClip + currentAmmo;
        currentAmmo = maxClip;
        isReloading = false;
        //sets animator bool to true so animation starts and disables animation,then fills ammo in our clip
    }
    public void Shoot()
    {
        currentAmmo--;
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
            //raycast from the camera
        {
            Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
                //checks if what we hit is destroyable
            {
                target.TakeDamage(damage);
                //damages target
            }
            if(target != null && target.isDestroyed)
            {
                myTargets++;
                //increases number of kills by one (for the objectives)
            }
        }
        particlesystem.Play();
        audioSource.PlayOneShot(audioClip);
        //plays audio and muzzle flash
        if(hit.rigidbody != null)
        {
            hit.rigidbody.AddForce(-hit.normal * 30f);
            //if what we hit has a rigidbody, we push it backwards a little bit
        }
        GameObject hitGo = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(hitGo, 2f);
        //smoke at bullet's position for 2 seconds
    }
}
