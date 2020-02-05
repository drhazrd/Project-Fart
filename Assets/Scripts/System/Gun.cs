﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float gunDamage;
    public float gunRange;
    public float impactForce;
    public float fireRate;
    public GameObject muzzleFlash;
    public GameObject impactFX;
    public int maxAmmo;
    public int currAmmo;
    public float reloadTime = 1f;
}
