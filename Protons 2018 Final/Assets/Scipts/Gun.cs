using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

    public float damage = 10f;
    public float range = 100f;

    public int maxAmmo = 10;
    private int currentAmmo;
    public float reloadTime = 1f;
    private bool isReloading = false;
    public Animator animator;
    private float nextTimeToFire = 0f;
    public float fireRate = 15f;

    public Camera fpsCam;

	private void Start()
	{
        currentAmmo = maxAmmo;
	}

	// Update is called once per frame
	void Update () {

        if(isReloading)
        {
            return;
        }

        if(currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }
		
        if(Input.GetButton("Fire1") && Time.time >= nextTimeToFire )
        {
            nextTimeToFire = Time.time + 1 / fireRate;
            Shoot();
        }
	}

    IEnumerator Reload ()
    {
        isReloading = true;
        Debug.Log("Reloading..");

        animator.SetBool("Reloading", true);

        yield return new WaitForSeconds(reloadTime);

        animator.SetBool("Reloading", false);
        currentAmmo = maxAmmo;
        isReloading = false;
    }
    void Shoot()
    {
        currentAmmo --;

        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }

    }
}
