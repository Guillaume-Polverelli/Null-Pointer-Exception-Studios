using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractable : MonoBehaviour
{
    public Dialogue dialogue;


    [SerializeField] private ChatBubble chatBubble;
    [SerializeField] private Transform Player;

    private string textToDisplay;


    public void Update()
    {
        if (dialogue.getStarted())
        {
            Vector3 targetPosition = new Vector3(Player.position.x,
                                                  transform.position.y,
                                                  Player.position.z);
            transform.LookAt(targetPosition);
        }
    }
    public void Interact()
    {
        if (dialogue.getStarted())
        {
            if (FindObjectOfType<DialogueManager>().isFinished())
            {
                gameObject.GetComponent<NPC_Behavior>().ChangeIsStopped(false);
                chatBubble.DestroyChatBubble();
                dialogue.setStarted(false);
            }
            else
            {
                textToDisplay = FindObjectOfType<DialogueManager>().DisplayNextSentence();
                chatBubble.NextMessage(textToDisplay);
            }
        }
        else
        {
            gameObject.GetComponent<NPC_Behavior>().ChangeIsStopped(true);
            dialogue.setStarted(true);
            textToDisplay = FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            chatBubble.Create(textToDisplay);
        }
    }
}
