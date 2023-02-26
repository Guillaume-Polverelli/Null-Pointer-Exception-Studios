using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro2Manager : MonoBehaviour
{
    [SerializeField] private GameObject errorLinePrefab;
    [SerializeField] private Transform errorContainer;

    [SerializeField] private string[] errors;

    [SerializeField] private float velocityText;

    private int currentError;
    // Start is called before the first frame update
    void Start()
    {
        PrintErrors();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PrintErrors()
    {
        if (currentError >= errors.Length)
        {
            EndError();
            return;
        }
        
        Transform[] errorLines = errorContainer.GetComponentsInChildren<Transform>();

        /*for(int i = 0; i < errorContainer.childCount; i++)
        {
            errorContainer.GetChild(i).SetSiblingIndex(errorContainer.childCount - i);
        }*/


        GameObject errorToAdd = Instantiate(errorLinePrefab, errorContainer);
        errorToAdd.transform.GetChild(1).GetComponent<TMP_Text>().text = "";
        StartCoroutine(Writer(errors[currentError], errorToAdd.transform.GetChild(1).GetComponent<TMP_Text>()));
        currentError++;
    }

    public void EndError()
    {
        SceneManager.LoadScene(3);
    }


    public IEnumerator Writer(string text, TMP_Text textMeshPro)
    {
        float pourcentage = 0f;
        float textVelocity = 1f / text.Length;

        while (pourcentage < 1f)
        {

            pourcentage = pourcentage + textVelocity;
            int nbCharacter = (int)(text.Length * pourcentage);

            string h = text.Substring(0, nbCharacter);
            textMeshPro.SetText(h);
            yield return new WaitForSeconds(velocityText);
        }

        yield return new WaitForSeconds(Random.Range(1.5f,3f));
        PrintErrors();
    }
}
