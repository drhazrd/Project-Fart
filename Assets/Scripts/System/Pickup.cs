using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour
{
    ThorQuestSystem thor;
    public float pickupRadius = 10f;
    public int itemValue;

    private void Start()
    {
        thor = FindObjectOfType<ThorQuestSystem>();
    }

    void OnTriggerEnter(Collider interact) {
        if(interact.tag == "Player")
        {
            Destroy(gameObject);
            thor.questCurrentAmount++;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, pickupRadius);
    }

}
