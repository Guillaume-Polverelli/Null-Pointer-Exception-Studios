using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractable : MonoBehaviour
{

    [SerializeField] private bool isGivingQuest;
    [SerializeField] private ChatBubble chatBubble;
    [SerializeField] private GameObject Player;
    [SerializeField] private AudioSource audioSource;

    [SerializeField] private DialogHUD textToHUD;

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
        if (GetComponent<Rencontre1>() && !GetComponent<Rencontre1>().GetDialogEnabled()) return;

        if ((isGivingQuest && !GameManager.Instance.getNPCToTalk() == this) || GetComponent<NPC_Behavior>().GetFighrMode() == true) return;

        Player.GetComponent<PlayerMovement>().setStopped(true);
        if (dialogue[nbDialogueToRead].getStarted())
        {
            if (FindObjectOfType<DialogueManager>().isFinished())
            {
                Player.GetComponent<PlayerInteract>().SetCanAttack(true);
                gameObject.GetComponent<NPC_Behavior>().ChangeIsStopped(false);
                Player.GetComponent<PlayerMovement>().setStopped(false);
                chatBubble.DestroyChatBubble();
                textToHUD.SetTextActive(false);
                dialogue[nbDialogueToRead].setStarted(false);
                GameManager.Instance.TestQuest(dialogue[nbDialogueToRead].quest);
                
            }
            else
            {
                
                textToDisplay = FindObjectOfType<DialogueManager>().DisplayNextSentence(audioSource);
                string[] splitArray = textToDisplay.Split(char.Parse(";"));
                string playerTalking = splitArray[0];
                textToDisplay = splitArray[1];
                if(playerTalking == "0")
                {
                    if(textToHUD.GetTextIsActive() == true)
                    {
                        StartCoroutine(textToHUD.Writer(textToDisplay));
                    }
                    else
                    {
                        chatBubble.DestroyChatBubble();
                        textToHUD.SetTextActive(true);
                        StartCoroutine(textToHUD.Writer(textToDisplay));
                    }
                }
                else if(playerTalking == "1")
                {
                    if(textToHUD.GetTextIsActive() == true)
                    {
                        textToHUD.SetTextActive(false);
                        chatBubble.Create(textToDisplay);
                    }
                    else
                    {
                        chatBubble.NextMessage(textToDisplay);
                    }
                }
                
            }
        }
        else
        {
            Player.GetComponent<PlayerInteract>().SetCanAttack(false);
            gameObject.GetComponent<NPC_Behavior>().ChangeIsStopped(true);
            dialogue[nbDialogueToRead].setStarted(true);
            textToDisplay = FindObjectOfType<DialogueManager>().StartDialogue(dialogue[nbDialogueToRead], audioSource);
            string[] splitArray = textToDisplay.Split(char.Parse(";"));
            string playerTalking = splitArray[0];
            textToDisplay = splitArray[1];
            if (playerTalking == "0")
            {
                textToHUD.SetTextActive(true);
                StartCoroutine(textToHUD.Writer(textToDisplay));
            }
            else if (playerTalking == "1")
            {
                chatBubble.Create(textToDisplay);
            }
            
        }
    }

    public bool getIsGiving()
    {
        return isGivingQuest;
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
