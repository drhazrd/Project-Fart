using UnityEngine;
using System.Collections;

public class enterExitV : MonoBehaviour
{
    private bool inVehicle = false;
    Vehicle vehicleScript;
    public GameObject guiObj;
    public GameObject camCar;
    GameObject player;


    void Start()
    {
        vehicleScript = GetComponent<Vehicle>();
        player = GameObject.FindWithTag("Player");
        guiObj.SetActive(false);
    }

    // Update is called once per frame
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && inVehicle == false)
        {
            guiObj.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                camCar.SetActive(true);
                guiObj.SetActive(false);
                player.transform.parent = gameObject.transform;
                vehicleScript.enabled = true;
                player.SetActive(false);
                inVehicle = true;
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            guiObj.SetActive(false);
        }
    }
    void Update()
    {
        if (inVehicle == true && Input.GetKeyDown(KeyCode.F))
        {
            camCar.SetActive(true);
            vehicleScript.enabled = false;
            player.SetActive(true);
            player.transform.parent = null;
            inVehicle = false;
        }
    }
}
