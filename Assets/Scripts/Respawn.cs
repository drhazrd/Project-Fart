using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour
{
    PlayerStats player;
    public GameObject[] respawnPoint;
    int respawnID;
    float respawnTimer;
    public bool isDead;
    // Use this for initialization
    void Start()
    {
        respawnID = Random.Range(0, respawnPoint.Length);
        player = GetComponent<PlayerStats>();
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.currentHealth <= 0 && isDead)
        {
            StartCoroutine(Revive());
        }
    }
    IEnumerator Revive()
    {
        player.GetComponent<PlayerMotor>().enabled = false;
        isDead = true;
        yield return new WaitForSeconds(respawnTimer);
        player.transform.position = respawnPoint[respawnID].transform.position;
        isDead = false;
        player.GetComponent<PlayerMotor>().enabled= true;
    }
}
