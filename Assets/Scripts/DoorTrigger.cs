using UnityEngine;
using System.Collections;

public class DoorTrigger : MonoBehaviour
{
    public int id;
    private void OnTriggerEnter(Collider other)
    {
        OdinEventSystem.current.OpenDoorTrigger(id);
    }

    private void OnTriggerExit(Collider other)
    {
        OdinEventSystem.current.CloseDoorTrigger(id);
        
    }
}
