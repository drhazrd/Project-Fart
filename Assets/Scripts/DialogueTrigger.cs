using UnityEngine;
using System.Collections;

public class DialogueTrigger : MonoBehaviour
{

    public Dialogue dialogue;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag =="Player" && Input.GetButtonDown("Submit1")|| Input.GetButtonDown("Submit2"))
        {
            TriggerDialogue();
        }
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

}
