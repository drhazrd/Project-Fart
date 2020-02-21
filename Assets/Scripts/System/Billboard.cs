using UnityEngine;
using System.Collections;

public class Billboard : MonoBehaviour
{

    public Transform cam;

    private void Awake()
    {
        cam = FindObjectOfType<PlayerCamera>().transform;
    }

    void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
    }

}
