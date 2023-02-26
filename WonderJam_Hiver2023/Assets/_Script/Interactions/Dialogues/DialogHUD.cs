using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogHUD : MonoBehaviour
{

    private TextMeshPro textMeshPro;
    [SerializeField] private float velocityTest;

    public void Awake()
    {
        textMeshPro = transform.GetChild(3).GetComponent<TextMeshPro>();
    }

    public IEnumerator Writer(string text)
    {
        float pourcentage = 0f;
        float textVelocity = 1f / text.Length;

        while (pourcentage < 1f)
        {

            pourcentage = pourcentage + textVelocity;
            int nbCharacter = (int)(text.Length * pourcentage);

            string h = text.Substring(0, nbCharacter);
            textMeshPro.SetText(h);
            yield return new WaitForSeconds(velocityTest);
        }
    }

    public void SetTextActive(bool value)
    {
        transform.GetChild(3).GetComponent<TextMeshPro>().enabled = value;
    }

    public bool GetTextIsActive()
    {
        return transform.GetChild(3).GetComponent<TextMeshPro>().IsActive();
    }
}
