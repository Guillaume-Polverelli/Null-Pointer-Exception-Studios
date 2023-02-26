using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Locker : MonoBehaviour
{
    [SerializeField] private GameObject warningText;
    [SerializeField] private string warningMessage;

    public void OnTriggerEnter(Collider other)
    {
        print("collision");
        if (other.gameObject.layer == 8)
        {
            if (warningText.active)
            {
                return;
            }
            warningText.GetComponent<TMP_Text>().SetText(warningMessage);
            warningText.SetActive(true);
            Invoke("ClearHUD", 3.0f);
        }
    }

    public void ClearHUD()
    {
        warningText.SetActive(false);
    }
}
