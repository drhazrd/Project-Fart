using UnityEngine;
using System.Collections;

public class DoorControllers : MonoBehaviour
{
    public int id;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        OdinEventSystem.current.onDoorTriggerEnter += OnDoorWayOpen;
        OdinEventSystem.current.onDoorTriggerExit += OnDoorWayClose;
    }

    void OnDoorWayOpen(int id)
    {
        if (id == this.id) { 
            anim.SetTrigger("OpenClose");
        }
    }

    void OnDoorWayClose(int id)
    {
        
        if (id == this.id)
        {
            anim.SetTrigger("OpenClose");
        }
    }
    void OnDestroy()
    {
        OdinEventSystem.current.onDoorTriggerEnter -= OnDoorWayOpen;
        OdinEventSystem.current.onDoorTriggerExit -= OnDoorWayClose;
        
    }
}
