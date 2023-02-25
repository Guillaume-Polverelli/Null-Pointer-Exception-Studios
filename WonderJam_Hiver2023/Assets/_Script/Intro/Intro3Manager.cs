using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro3Manager : MonoBehaviour
{
    [SerializeField] private TMP_Text introTextMesh;
    [SerializeField] private string text;
    [SerializeField] private float velocityText;

    [SerializeField] private AudioSource musicSource;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Writer());
    }

    // Update is called once per frame
    void Update()
    {

    }




    public IEnumerator Writer()
    {
        float pourcentage = 0f;
        float textVelocity = 1f / text.Length;

        while (pourcentage < 1f)
        {

            pourcentage = pourcentage + textVelocity;
            int nbCharacter = (int)(text.Length * pourcentage);

            string h = text.Substring(0, nbCharacter);
            introTextMesh.SetText(h);
            yield return new WaitForSeconds(velocityText);
        }

        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(3);
    }
}
