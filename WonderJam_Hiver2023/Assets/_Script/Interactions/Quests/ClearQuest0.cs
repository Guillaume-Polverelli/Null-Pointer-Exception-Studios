using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearQuest0 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameManager.Instance.EndQuest_0();
        gameObject.SetActive(false);
    }
}
