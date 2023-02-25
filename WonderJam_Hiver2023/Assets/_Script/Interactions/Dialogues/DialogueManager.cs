using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{

    private Queue<string> sentences;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public string StartDialogue(Dialogue dialogue)
    {

        Debug.Log("Starting conversation with" + dialogue.name);

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        return DisplayNextSentence();
    }

    public string DisplayNextSentence()
    {

        string sentence = sentences.Dequeue();
        return sentence;
    }

    public bool isFinished()
    {
        return (sentences.Count == 0);
    }
}
