using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Epee : MonoBehaviour
{
    private NPCInteractable swordQuest;
    public void Awake()
    {
        swordQuest = gameObject.GetComponent<NPCInteractable>();
    }

    public void IncreaseDialogLine()
    {
        swordQuest.SetNbDialog(swordQuest.GetNbDialog() + 1);
    }
}
