using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSwitch : MonoBehaviour
{
    public GameObject instructorText;
    Animator anim;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            //instructorText.gameObject.SetActive(true);
            anim = GetComponent<Animator>();
            if (Input.GetKeyDown(KeyCode.E))
            {

                anim.SetTrigger("OpenClose");
            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "Player")
        {
            instructorText.gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            instructorText.gameObject.SetActive(true);
        }
    }
}
