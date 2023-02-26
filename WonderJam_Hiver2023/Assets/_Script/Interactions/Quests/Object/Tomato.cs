using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tomato : MonoBehaviour
{

    [SerializeField] private SpriteRenderer background;
    private NPCInteractable tomatoQuest;
    public void Awake()
    {
        tomatoQuest = gameObject.GetComponent<NPCInteractable>();
    }

    public void IncreaseDialogLine()
    {
        tomatoQuest.SetNbDialog(tomatoQuest.GetNbDialog() + 1);
    }

    public void setVisibilityIcon(bool value)
    {
        tomatoQuest.transform.GetChild(2).gameObject.SetActive(value);
    }

    public void ChangeColorIcon(Vector3 color)
    {

        background.color = new Color(color.x, color.y, color.z);
    }
}
