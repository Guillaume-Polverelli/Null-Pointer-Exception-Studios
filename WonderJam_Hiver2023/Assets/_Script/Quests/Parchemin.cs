using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Parchemin : MonoBehaviour
{
    [SerializeField] private SpriteRenderer background;
    private NPCInteractable npc;

    void Start()
    {
        npc = GetComponent<NPCInteractable>();
    }


    public void ParcheminCollected()
    {
        npc.SetNbDialog(npc.GetNbDialog()+1);
    }

    
}
