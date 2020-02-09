using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun1 : Gun
{
    public Camera fpsCam;
    PlayerMotor pMotor;
    private float nextTimeToFire = 0;
    public Animator anim;
    public int maxAmmo;
    public int currAmmo;
    public Text ammoText;
    public float reloadTimer = .15f;

    bool isReloading = false;
    //private float nextTimeToFire;
    // Update is called once per frame
    void Start()
    {
        pMotor = GetComponentInParent<PlayerMotor>();
        anim = GetComponentInChildren<Animator>();
        currAmmo = maxAmmo;
    }
    void Update()
    {
        ammoText.text = currAmmo.ToString() + " / " + maxAmmo.ToString();
        if (isReloading)
        {
            return;
        }
        if (currAmmo<=0)
        {
            StartCoroutine(Reload(reloadTimer));
            return;
        }
        if ((Input.GetAxis("Fire1"+pMotor.playerNumber) > 0.1f)&& Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Debug.Log("Bullet, Bullet, Bullet!");
            Shoot();
        }
    }
    void Shoot()
    {
        anim.SetTrigger("isFiring");
        muzzleFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, gunRange))
        {
            Debug.Log("shoots: " + hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(gunDamage);
            }
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
            GameObject impactGO = Instantiate(impactFX, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);

        }
    }
    IEnumerator Reload(float reloadTime)
    {
        anim.SetBool("isEmpty",true);
        isReloading = true;
        Debug.Log("Reloading...");
        anim.SetBool("isEmpty",false);
        anim.SetBool("isReloading",true);
        yield return new WaitForSeconds(reloadTime);
        anim.SetBool("isReloading",false);
        currAmmo = maxAmmo;
        isReloading = false;
    }
}
