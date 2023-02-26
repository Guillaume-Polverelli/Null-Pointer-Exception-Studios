using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string quest;

    [TextArea(3, 10)]
    public string[] sentences;

    public AudioClip[] audioClips;

    private bool hasStarted = false;

    public void setStarted(bool condition)
    {
        hasStarted = condition;
    }

    public bool getStarted()
    {
        return hasStarted;
    }
}
