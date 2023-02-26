using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tomato : MonoBehaviour
{

    private NPCInteractable tomatoQuest;
    public void Awake()
    {
        tomatoQuest = gameObject.GetComponent<NPCInteractable>();
    }

    public void IncreaseDialogLine()
    {
        tomatoQuest.SetNbDialog(tomatoQuest.GetNbDialog() + 1);
    }
}
