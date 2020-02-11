using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowFunction : MonoBehaviour{
    public float throwForce = 40f;
    public GameObject throwPrefab;
    public PlayerMotor playerMotor;

    void Start()
    {
        playerMotor = GetComponentInParent<PlayerMotor>();
    }
    void Update(){
        if (Input.GetButtonDown("Fire2"+playerMotor.playerNumber)){
            ThrowGrenade();
        }
    }
    void ThrowGrenade(){
        GameObject nade = Instantiate(throwPrefab, transform.position, transform.rotation);
        Rigidbody rb = nade.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward*throwForce, ForceMode.VelocityChange);
    }
}
