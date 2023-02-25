using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractable : MonoBehaviour
{
    public Dialogue dialogue;
    [SerializeField] private ChatBubble chatBubble;
    public void Interact()
    {
        if (dialogue.hasStarted)
        {
            gameObject.GetComponent<NPC_Behavior>().ChangeIsStopped(!FindObjectOfType<DialogueManager>().isFinished());
            FindObjectOfType<DialogueManager>().DisplayNextSentence();
        }
        else
        {
            gameObject.GetComponent<NPC_Behavior>().ChangeIsStopped(true);
            dialogue.hasStarted = true;
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
    }
}
