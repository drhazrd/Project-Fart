using UnityEngine;
using System.Collections;

public class DialogueTrigger : MonoBehaviour
{

    public Dialogue dialogue;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag =="Player" && Input.GetButtonDown("InteractP1") || Input.GetButtonDown("InteractP2"))
        {
            TriggerDialogue();
        }
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

}
