using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowFunction : MonoBehaviour{
public float throwForce = 40f;
public GameObject throwPrefab;

void Update(){
if (Input.GetButtonDown("Throw")){
ThrowGrenade();
}
}
ThrowGrenade(){
Gameobject nade = Intansitate(throwPrefab, tranform.position, transform.rotation);
Rigidbody rb = nade.GetComponent<Rigidbody>();
rb.AddForce(transfrom.forward*throwForce, ForceMode.VelocityChange);
}
}
