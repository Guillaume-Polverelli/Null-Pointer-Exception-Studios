using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteractable : MonoBehaviour
{

    [SerializeField] private int objectId;
    public void Interact()
    {
        GameManager.Instance.AddObject(objectId);
        Destroy(gameObject);
    }
}
