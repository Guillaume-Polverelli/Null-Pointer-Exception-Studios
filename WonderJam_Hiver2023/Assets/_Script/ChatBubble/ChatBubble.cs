using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ChatBubble : MonoBehaviour
{

    public void Create(string text)
    {
        gameObject.SetActive(true);

        Setup(text);

        gameObject.GetComponent<Animation>().Play();

    }

    public void NextMessage(string text)
    {
        Setup(text);
    }

    public void DestroyChatBubble()
    {
        gameObject.SetActive(false);
    }

    private SpriteRenderer backgroundSpriteRenderer;
    private TextMeshPro textMeshPro;

    [SerializeField] private float velocityTest;



    private void Awake()
    {
        backgroundSpriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        textMeshPro = transform.GetChild(1).GetComponent<TextMeshPro>();
    
    
    }

    private void Setup( string text)
    {
        textMeshPro.SetText(text);
        textMeshPro.ForceMeshUpdate();
        Vector2 textSize = textMeshPro.GetRenderedValues(false);

        Vector2 padding = new Vector2(3f, 3f);
        backgroundSpriteRenderer.size = textSize + padding;

        //Vector3 offset = new Vector3(-8f, 0f);
        //backgroundSpriteRenderer.transform.localPosition =
            //new Vector3(backgroundSpriteRenderer.size.x / 2f, 0f) + offset;

        StartCoroutine(Writer(text));

    }

    public IEnumerator Writer(string text)
    {
        float pourcentage = 0f;
        float textVelocity = 1f / text.Length;

        while(pourcentage < 1f)
        {

            pourcentage = pourcentage + textVelocity;
            int nbCharacter = (int) (text.Length * pourcentage);

            string h = text.Substring(0, nbCharacter);
            textMeshPro.SetText(h);
            yield return new WaitForSeconds(velocityTest);
        }
    }
}
