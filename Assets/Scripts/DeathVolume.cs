using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathVolume : MonoBehaviour
{
    [SerializeField]
    private Transform play1Trans, play2Trans;
    [SerializeField]
    private Transform[] playTrans;
    [SerializeField]private Transform respawnPoint;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") { 
             other.transform.position = respawnPoint.transform.position;
        }
        else
        {
            Destroy(other.gameObject);
        }
    }
}
