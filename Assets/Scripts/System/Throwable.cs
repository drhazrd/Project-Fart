using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwable : MonoBehaviour
{
    public float delay = 3f;
    public float radius = 3f;
    public float explosionForce = 700f;
    public float countDown;
    bool hasExploded = false;
    public GameObject explosionFX;
    // Start is called before the first frame update
    void Start()
    {
        countDown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        countDown-=Time.deltaTime;
        if(countDown <= 0f && !hasExploded){
            Expolde();
            hasExploded = true;
        }
    }
    void Expolde(){
        Debug.Log("BOOOM!!");
        Instantiate(explosionFX, transform.position, transform.rotation);
        Collider[] collidersToDestroy = Physics.OverlapSphere(transform.position, radius);
        foreach(Collider nearbyObj in collidersToDestroy)
        {
            
        }
        Collider[] collidersToMove = Physics.OverlapSphere(transform.position, radius);
        foreach(Collider nearbyObj in collidersToMove)
        {
            Rigidbody rb = nearbyObj.GetComponent<Rigidbody>();
            if(rb != null){
                rb.AddExplosionForce(explosionForce, transform.position, radius);
            }
        }
        Destroy(gameObject);
    }
}
