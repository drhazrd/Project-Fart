﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun3 : Gun
{
    public Camera fpsCam;
    PlayerMotor pMotor;
    private float nextTimeToFire = 0;
    public int gunDamage;
    public int maxAmmo;
    public int currAmmo;
    public Text ammoText;
    //private float nextTimeToFire;
    // Update is called once per frame
    void Start()
    {
        pMotor = GetComponentInParent<PlayerMotor>();
        currAmmo = maxAmmo;
    }
    void Update()
    {
        ammoText.text = currAmmo.ToString() + " / " + maxAmmo.ToString();
        if ((Input.GetAxis("Fire1" + pMotor.playerNumber) > 0.1f) && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Debug.Log("Bullet, Bullet, Bullet!");
            Shoot();
        }
    }
    void Shoot()
    {
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
}
