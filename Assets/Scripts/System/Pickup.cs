using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour
{
    public float pickupRadius = 10f;
    public int itemValue;

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, pickupRadius);
    }

}
