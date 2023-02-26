using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private GameObject locker_Quest0;
    [SerializeField] private GameObject locker_Quest4;
    [SerializeField] private GameObject locker_Quest6;

    [SerializeField] private TextMeshProUGUI titleQuest;
    [SerializeField] private TextMeshProUGUI objectifQuest;
    [SerializeField] private TextMeshProUGUI progressionQuest;

    [SerializeField] private NPCInteractable[] listOfNPC;

    private NPCInteractable NPCToTalkTo;
    private int mushroomCollected = 0;
    private int sunflowerCollected = 0;
    private bool parchmentCollected = false;
    private bool artefactCollected = false;
    private bool swordCollected = false;

    private bool isQuestActive;

    public bool GetQuestActive()
    {
        return isQuestActive;
    }

    public void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void Start()
    {
        UnlockQuest_0();
        NPCToTalkTo = listOfNPC[0];
    }

    public void TestQuest(string NPC_name)
    {
        switch (NPC_name)
        {
            case ("Quest1"):
                UnlockQuest_1();
                break;
            case ("Quest2"):
                UnlockQuest_2();
                break;
            case ("Rencontre1"):
                //Mettre héro en evil
                break;
            default:
                break;
        }
    }

    private void ShowQuest()
    {
        titleQuest.gameObject.SetActive(true);
        objectifQuest.gameObject.SetActive(true);
        progressionQuest.gameObject.SetActive(true);
    }

    private void HideQuest()
    {
        titleQuest.gameObject.SetActive(false);
        objectifQuest.gameObject.SetActive(false);
        progressionQuest.gameObject.SetActive(false);
    }

    public void TriggerLocker_0()
    {
        locker_Quest0.SetActive(false);
    }

    public void UnlockQuest_0()
    {
        isQuestActive = true;
        titleQuest.SetText("Le début d'une nouvelle aventure !");
        objectifQuest.SetText("Vous avez entendu parlé d'un petit village perdu dans la forêt. Des rumeurs racontent que le mage ayant découvert la prophétie s'y trouve...");
        progressionQuest.SetText("Trouvez le moyen de vous rendre au village.");
        ShowQuest();
    }

    public void UnlockQuest_1()
    {
        isQuestActive = true;
        locker_Quest0.SetActive(false);
        titleQuest.SetText("A la cueillette aux champignons !");
        objectifQuest.SetText("Jacquie vous a commandité pour que vous lui rameniez trois gros champignons de la forêt. Il pourra peut-être alors vous en dire plus sur la prophétie...");
        setTextQuest1("Total de champignons ramassés: " + mushroomCollected + "/3");
        ShowQuest();
    }

    public void setTextQuest1(string progress)
    {
        progressionQuest.SetText(progress);
    }

    public void UnlockQuest_2()
    {
        isQuestActive = true;
        listOfNPC[1].gameObject.SetActive(true);
    }

    public void UnlockQuest_3()
    {
        isQuestActive = true;

    }

    public void UnlockQuest_4()
    {
        isQuestActive = true;
    }

    public void UnlockQuest_5()
    {
        isQuestActive = true;
    }

    public void UnlockQuest_6()
    {
        isQuestActive = true;
    }

    public void EndQuest_0()
    {
        isQuestActive = false;
        HideQuest();
        titleQuest.SetText("Quest cleared !");
        titleQuest.gameObject.SetActive(true);
        Invoke("HideQuest", 4.0f);
    }

    public void EndQuest_1()
    {
        isQuestActive = false;
        NPCToTalkTo = listOfNPC[1];
        UnlockQuest_2();
    }

    public void EndQuest_2()
    {
        isQuestActive = false;
        NPCToTalkTo = listOfNPC[2];
    }

    public void EndQuest_3()
    {
        isQuestActive = false;
        NPCToTalkTo = listOfNPC[3];
    }

    public void EndQuest_4()
    {
        isQuestActive = false;
    }

    public void EndQuest_5()
    {
        isQuestActive = false;
    }

    public void EndQuest_6()
    {
        isQuestActive = false;
    }
}
