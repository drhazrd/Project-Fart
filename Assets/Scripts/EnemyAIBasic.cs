using UnityEngine;
using System.Collections;

public class EnemyAIBasic : MonoBehaviour
{
    public Transform targetObj;
    float objectiveDistance;
    public GameObject[] patrolPoints;
    float rotationDampner = 3f;

    // Use this for initialization
    void Start()
    {
        //targetObj = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (targetObj == null)
        {
            targetObj = FindObjectOfType<PlayerStats>().transform;
        }
        //else
        //{
        //    targetObj = patrolPoints[Random.Range(0, patrolPoints.Length)].transform;
        //}
        objectiveDistance = Vector3.Distance(targetObj.position, transform.position);
        if (objectiveDistance < 13f)
        {
            LookAtPlayer();
        }
    }
    void LookAtPlayer()
    { 
        Quaternion rotation = Quaternion.LookRotation(targetObj.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation,Time.deltaTime*rotationDampner);
    }
}
