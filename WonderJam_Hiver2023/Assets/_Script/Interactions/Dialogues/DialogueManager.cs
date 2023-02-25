using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{

    private Queue<string> sentences;
    private Queue<AudioClip> audioClips;


    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        audioClips = new Queue<AudioClip>();
    }

    public string StartDialogue(Dialogue dialogue, AudioSource audioSource)
    {

        Debug.Log("Starting conversation with" + dialogue.name);

        sentences.Clear();
        audioClips.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        foreach(AudioClip clip in dialogue.audioClips)
        {
            audioClips.Enqueue(clip);
        }

        return DisplayNextSentence(audioSource);
    }

    public string DisplayNextSentence(AudioSource audioSource)
    {
        string sentence = sentences.Dequeue();
        AudioClip clip = audioClips.Dequeue();
        if(clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
        return sentence;
    }

    public bool isFinished()
    {
        return (sentences.Count == 0);
    }
}
