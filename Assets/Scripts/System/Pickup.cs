using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour
{
    public float pickupRadius = 10f;
    public int itemValue;

    void OnTriggerEnter(Collider interact) {
        if(interact.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, pickupRadius);
    }

}
