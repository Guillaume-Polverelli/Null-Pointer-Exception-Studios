using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractable : MonoBehaviour
{
    [SerializeField] private ChatBubble chatBubble;
    public void Interact()
    {
        chatBubble.Create("Hello there !");
    }
}
