using UnityEngine;
using System.Collections;

public class Ammo : Pickup
{
    public ParticleSystem pickupEffect;
    // Use this for initialization
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup(other);
            Debug.Log("Collect");
        }
    }
    void Pickup(Collider player)
    {
        Debug.Log("Collected:");
        PlayerStats stats = player.GetComponent<PlayerStats>();
        stats.heldAmmo = stats.heldAmmo + itemValue;
        Destroy(gameObject);
    }
}
