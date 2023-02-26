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

    private int mushroomCollected = 0;
    private int sunflowerCollected = 0;
    private bool parchmentCollected = false;
    private bool artefactCollected = false;
    private bool swordCollected = false;

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
    }

    public void TestQuest(string NPC_name)
    {
        switch (NPC_name)
        {
            case ("Jacquie"):
                UnlockQuest_1();
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
        titleQuest.SetText("Le début d'une nouvelle aventure !");
        objectifQuest.SetText("Vous avez entendu parlé d'un petit village perdu dans la forêt. Des rumeurs racontent que le mage ayant découvert la prophétie s'y trouve...");
        progressionQuest.SetText("Trouvez le moyen de vous rendre au village.");
        ShowQuest();
    }

    public void UnlockQuest_1()
    {
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

    }

    public void UnlockQuest_3()
    {

    }

    public void UnlockQuest_4()
    {

    }

    public void UnlockQuest_5()
    {

    }

    public void UnlockQuest_6()
    {

    }

    public void EndQuest_0()
    {
        HideQuest();
        titleQuest.SetText("Quest cleared !");
        titleQuest.gameObject.SetActive(true);
        Invoke("HideQuest", 4.0f);
    }

    public void EndQuest_1()
    {

    }

    public void EndQuest_2()
    {

    }

    public void EndQuest_3()
    {

    }

    public void EndQuest_4()
    {

    }

    public void EndQuest_5()
    {

    }

    public void EndQuest_6()
    {

    }
}
