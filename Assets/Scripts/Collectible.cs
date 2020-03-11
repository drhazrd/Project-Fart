using UnityEngine;
using System.Collections;

public class Collectible : Pickup
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
        stats.currScore = stats.currScore + itemValue;
        Destroy(gameObject);
    }
}
