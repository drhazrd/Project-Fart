using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

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
    public float coolDownTimer = .15f;
    AudioSource mAudio;
    public AudioClip reloadAudio;
    public AudioClip fireAudio;

    bool isFiring = false;
    bool isReloading = false;
    //private float nextTimeToFire;
    // Update is called once per frame
    void Start()
    {
        pMotor = GetComponentInParent<PlayerMotor>();
        anim = GetComponentInChildren<Animator>();
        mAudio = GetComponent<AudioSource>();
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
            StartCoroutine(Reload(reloadTimer, coolDownTimer));
            return;
        }
        if ((Input.GetAxis("Fire1"+pMotor.playerNumber) > 0.1f)&& Time.time >= nextTimeToFire&&!isFiring)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Debug.Log("Bullet, Bullet, Bullet!");
            Shoot();
            isFiring = true;
        }else if (Input.GetAxis("Fire1" + pMotor.playerNumber) < 0.1f)
        {
            isFiring = false;
        }

    }
    void Shoot()
    {
        anim.SetTrigger("isFiring");
        currAmmo--;
        muzzleFlash.Play();
        mAudio.Play();
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
    IEnumerator Reload(float reloadTime, float gunCoolDown)
    {
        isReloading = true;
        Debug.Log("Reloading...");
        anim.SetBool("isEmpty", true);
        anim.SetBool("isReloading",true);
        yield return new WaitForSeconds(reloadTime);
        anim.SetBool("isEmpty", false);
        yield return new WaitForSeconds(gunCoolDown);
        anim.SetBool("isReloading",false);
        currAmmo = maxAmmo;
        isReloading = false;
    }
}
