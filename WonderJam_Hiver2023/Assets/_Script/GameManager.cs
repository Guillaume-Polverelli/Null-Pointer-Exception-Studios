using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private GameObject player;

    [SerializeField] private GameObject locker_Quest0;
    [SerializeField] private GameObject locker_Quest1;
    [SerializeField] private GameObject locker_Quest3;
    [SerializeField] private GameObject locker_Quest4;

    [SerializeField] private TextMeshProUGUI titleQuest;
    [SerializeField] private TextMeshProUGUI objectifQuest;
    [SerializeField] private TextMeshProUGUI progressionQuest;

    [SerializeField] private NPCInteractable[] listOfNPC;

    [SerializeField] private Tomato tomatoQuest;
    [SerializeField] private Parchemin parcheminQuest;
    [SerializeField] private Epee swordQuest;

    [SerializeField] private SceneFinale finalScene;

    [SerializeField] private Transform parcheminParent;
    [SerializeField] private GameObject parcheminPrefab;

    [SerializeField] private Transform[] spawnPointsHero;

    private NPCInteractable NPCToTalkTo;
    private int tomatoCollected = 0;
    private bool parchmentCollected = false;
    private bool swordCollected = false;

    private bool isQuestActive;

    public NPCInteractable getNPCToTalk()
    {
        return NPCToTalkTo;
    }
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
        //NPCToTalkTo = listOfNPC[0];
    }

    public void TestQuest(string NPC_name)
    {
        switch (NPC_name)
        {
            case ("Quest1"):
                if (!isQuestActive)
                {
                    UnlockQuest_1();
                }
                break;
            case ("Rencontre1"):
                EndQuest_1();
                UnlockQuest_2();
                break;
            case ("Combat1"):
                listOfNPC[0].GetComponent<NPC_Behavior>().SetAttackRange(1);
                break;
            case ("Quest3"):
                UnlockQuest_3();
                break;
            case ("Combat2"):
                listOfNPC[1].GetComponent<NPC_Behavior>().SetAttackRange(1);
                break;
            case ("Quest4"):
                EndQuest_3();
                Invoke("UnlockQuest_4", 5.0f);
                break;
            case ("Combat3"):
                listOfNPC[2].GetComponent<NPC_Behavior>().SetAttackRange(1);
                break;
            case ("FeinteMort"):
                swordQuest.IncreaseDialogLine();
                finalScene.RemoveAnim();
                break;
            case ("Combat4"):
                listOfNPC[2].GetComponent<NPC_Behavior>().SetAttackRange(1);
                player.GetComponent<PlayerInteract>().setAttack(800);
                player.GetComponent<Character>().setHealth(20000f, 100f);
                break;
            case ("TheEnd"):
                player.GetComponent<PlayerMovement>().setStopped(true);
                swordQuest.IncreaseDialogLine();
                finalScene.HeroHasLeftGame();
                break;
            case ("EndGame"):
                finalScene.FinishTheGame();
                player.GetComponent<PlayerMovement>().setStopped(true);
                break;
            default:
                break;
        }
    }

    public void AddObject(int objectInteractable)
    {
        switch (objectInteractable)
        {
            case 0:
                tomatoCollected++;
                setTextQuest("Total de tomates ramass�es: " + tomatoCollected + " / 15");
                if (tomatoCollected == 15)
                {
                    tomatoQuest.IncreaseDialogLine();
                    tomatoQuest.ChangeColorIcon(new Vector3(0, 200, 0));
                }
                break;
            case 1:
                parchmentCollected = true;
                GameObject parchemin = Instantiate(parcheminPrefab, parcheminParent);
                parchemin.GetComponentInChildren<ParcheminErrorText>().setPlayer(player);
                player.GetComponent<PlayerMovement>().setStopped(true);
                break;
            case 2:
                swordCollected = true;
                UnlockRencontre3();
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

  
    public void setTextQuest(string progress)
    {
        progressionQuest.SetText(progress);
    }

    public void UnlockQuest_0()
    {
        isQuestActive = true;
        titleQuest.SetText("Le d�but d'une nouvelle aventure !");
        objectifQuest.SetText("Vous avez entendu parl� d'un petit village perdu dans la for�t. Des rumeurs racontent que le mage ayant d�couvert la proph�tie s'y trouve...");
        progressionQuest.SetText("Trouvez le moyen de vous rendre au village.");
        ShowQuest();
        NPCToTalkTo = listOfNPC[3];
    }

    public void UnlockQuest_1()
    {
        isQuestActive = true;
        locker_Quest1.SetActive(false);
        titleQuest.SetText("Rouge comme une tomate !");
        objectifQuest.SetText("Jacquie vous a commandit� pour que vous lui rameniez quinze grosses tomates des champs du village. Elle pourra peut-�tre alors vous en dire plus sur la proph�tie...");
        setTextQuest("Total de tomates ramass�es: " + tomatoCollected + "/15");
        ShowQuest();
        tomatoQuest.IncreaseDialogLine();
        tomatoQuest.ChangeColorIcon(new Vector3(50, 50, 50));
    }

    public void UnlockQuest_2()
    {
        isQuestActive = true;
        NPCToTalkTo = null;
        listOfNPC[0].gameObject.SetActive(true);
    }

    public void UnlockQuest_3()
    {
        isQuestActive = true;
        locker_Quest3.SetActive(false);
        titleQuest.SetText("Par tous les chemins...");
        objectifQuest.SetText("Beno�t, le pr�tre du village, vous indique qu'il �tait en possession d'un parchemin parlant de la proph�tie. Cependant, celui-ci se trouverait dans un donjon �loign�.");
        setTextQuest("Parchemin collect� : 0/1");
        ShowQuest();
        parcheminQuest.IncreaseDialogLine();
        parcheminQuest.ChangeColorIcon(new Vector3(50, 50, 50));
    }

    public void UnlockQuest_4()
    {
        isQuestActive = true;
        locker_Quest4.SetActive(false);
        titleQuest.SetText("R�union au sommet");
        objectifQuest.SetText("Gr�ce au pr�tre, vous avez pu en apprendre plus sur la proph�tie. Tout semble converger vers une myst�rieuse �p�e. Cela ne vous laisse pas indiff�rent et vous d�cidez de partir � sa recherche.");
        setTextQuest("Ep�e d�moniaque collect�e : 0/1");
        ShowQuest();
        //swordQuest.IncreaseDialogLine();
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
        tomatoQuest.setVisibilityIcon(true);
    }

    public void EndQuest_1()
    {
        isQuestActive = false;
        NPCToTalkTo = null;
        HideQuest();
        titleQuest.SetText("Quest cleared !");
        titleQuest.gameObject.SetActive(true);
        Invoke("HideQuest", 4.0f);
        tomatoQuest.setVisibilityIcon(false);
    }

    public void EndQuest_2()
    {
        isQuestActive = false;
        NPCToTalkTo = listOfNPC[4];
        parcheminQuest.setVisibilityIcon(true);
    }

    public void EndQuest_3()
    {
        isQuestActive = false;
        NPCToTalkTo = null;
        HideQuest();
        titleQuest.SetText("Quest cleared !");
        titleQuest.gameObject.SetActive(true);
        Invoke("HideQuest", 4.0f);
        parcheminQuest.setVisibilityIcon(false);
       
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

    public void UnlockRencontre2()
    {
        NPCToTalkTo = null;
        parcheminQuest.IncreaseDialogLine();

        setTextQuest("Parchemin collect� : 1/1");
        ShowQuest();

        listOfNPC[1].gameObject.SetActive(true);
        listOfNPC[1].gameObject.GetComponent<NPC_Behavior>().ChangeIsStopped(true);
    }

    public void EndRencontre_2()
    {
        NPCToTalkTo = listOfNPC[4];
    }

    public void UnlockRencontre3()
    {
        setTextQuest("Ep�e d�moniaque collect�e : 1/1");
        ShowQuest();

        listOfNPC[2].gameObject.SetActive(true);
        listOfNPC[2].gameObject.GetComponent<NPC_Behavior>().ChangeIsStopped(true);
    }

    public void EndRencontre_3()
    {
        swordQuest.IncreaseDialogLine();
        listOfNPC[2].Interact();
    }

    public void CalmHero()
    {
        listOfNPC[2].GetComponent<NPC_Behavior>().SetAttackRange(0);
        swordQuest.IncreaseDialogLine();
    }
}
