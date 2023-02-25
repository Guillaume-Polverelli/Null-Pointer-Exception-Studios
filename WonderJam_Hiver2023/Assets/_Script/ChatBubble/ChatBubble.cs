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

    public static void DestroyChatBubble(Transform chatbubble)
    {
        Destroy(chatbubble);
    }

    private SpriteRenderer backgroundSpriteRenderer;
    private TextMeshPro textMeshPro;

    [SerializeField] private float velocityTest;



    private void Awake()
    {
        backgroundSpriteRenderer = transform.Find("Background").GetComponent<SpriteRenderer>();
        textMeshPro = transform.Find("Text").GetComponent<TextMeshPro>();
    
    
    }
    private void Start()
    {
        Setup("Hello World ! udyfyg uygusy fbduyby byb ybfy wvybyc bfyb vwybvwy gbyv ");
    }

    private void Setup( string text)
    {
        textMeshPro.SetText(text);
        textMeshPro.ForceMeshUpdate();
        Vector2 textSize = textMeshPro.GetRenderedValues(false);

        Vector2 padding = new Vector2(3f, 3f);
        backgroundSpriteRenderer.size = textSize + padding;

        Vector3 offset = new Vector3(-8f, 0f);
        backgroundSpriteRenderer.transform.localPosition =
            new Vector3(backgroundSpriteRenderer.size.x / 2f, 0f) + offset;

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
