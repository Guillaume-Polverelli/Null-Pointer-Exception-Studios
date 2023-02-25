using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private GameObject locker_Quest1;
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

    public void UnlockQuest_1()
    {
        locker_Quest1.SetActive(false);
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
