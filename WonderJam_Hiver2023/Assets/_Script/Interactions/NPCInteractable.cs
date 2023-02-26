using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractable : MonoBehaviour
{

    
    [SerializeField] private ChatBubble chatBubble;
    [SerializeField] private GameObject Player;
    [SerializeField] private AudioSource audioSource;

    public Dialogue[] dialogue;

    private string textToDisplay;
    private int nbDialogueToRead = 0;


    public void Update()
    {
        if (dialogue[nbDialogueToRead].getStarted())
        {
            Vector3 targetPosition = new Vector3(Player.transform.position.x,
                                                  transform.position.y,
                                                  Player.transform.position.z);
            transform.LookAt(targetPosition);
        }
    }
    public void Interact()
    {
        //if(GameManager.Instance.)
        if (dialogue[nbDialogueToRead].getStarted())
        {
            if (FindObjectOfType<DialogueManager>().isFinished())
            {
                gameObject.GetComponent<NPC_Behavior>().ChangeIsStopped(false);
                chatBubble.DestroyChatBubble();
                Player.GetComponent<PlayerMovement>().setStopped(false);
                dialogue[nbDialogueToRead].setStarted(false);
            }
            else
            {
                textToDisplay = FindObjectOfType<DialogueManager>().DisplayNextSentence(audioSource);
                chatBubble.NextMessage(textToDisplay);
                if (FindObjectOfType<DialogueManager>().isFinished())
                {
                    GameManager.Instance.TestQuest(dialogue[nbDialogueToRead].quest);
                }
            }
        }
        else
        {
            gameObject.GetComponent<NPC_Behavior>().ChangeIsStopped(true);
            dialogue[nbDialogueToRead].setStarted(true);
            textToDisplay = FindObjectOfType<DialogueManager>().StartDialogue(dialogue[nbDialogueToRead], audioSource);
            chatBubble.Create(textToDisplay);
        }
    }

    public void SetNbDialog(int nb)
    {
        nbDialogueToRead = nb;
    }

    public int GetNbDialog()
    {
        return nbDialogueToRead;
    }
}
