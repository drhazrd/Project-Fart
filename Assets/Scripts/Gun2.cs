using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun2 : Gun
{
    public Camera fpsCam;
    PlayerMotor pMotor;
<<<<<<< HEAD
    private float nextTimeToFire = 0;
=======
    private float nextTimeToFire;
>>>>>>> c5cc1d1a613261b6ab30894cf94bfd18390ea3bf
    // Update is called once per frame
    void Start()
    {
        pMotor = GetComponentInParent<PlayerMotor>();
    }
    void Update()
    {
<<<<<<< HEAD
        if ((Input.GetAxis("Fire1" + pMotor.playerNumber) > 0.1f) && Time.time >= nextTimeToFire)
=======
        if ((Input.GetAxis("Fire1"+pMotor.playerNumber) > 0.1f)&& Time.time >= nextTimeToFire)
>>>>>>> c5cc1d1a613261b6ab30894cf94bfd18390ea3bf
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Debug.Log("Bullet, Bullet, Bullet!");
            Shoot();
        }
    }
    void Shoot()
    {
        //muzzleFlash.Play();
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
