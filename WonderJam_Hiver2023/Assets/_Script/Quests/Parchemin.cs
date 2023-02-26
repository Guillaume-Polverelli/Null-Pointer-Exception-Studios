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


    public void IncreaseDialogLine()
    {
        npc.SetNbDialog(npc.GetNbDialog()+1);
    }

    public void setVisibilityIcon(bool value)
    {
        npc.transform.GetChild(2).gameObject.SetActive(value);
    }

    public void ChangeColorIcon(Vector3 color)
    {

        background.color = new Color(color.x, color.y, color.z);
    }


}
