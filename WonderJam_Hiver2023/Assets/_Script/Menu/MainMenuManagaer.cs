using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManagaer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickedPlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void OnClickedQuitButton()
    {
        Application.Quit();
    }

    public void OnClickedCreditsButton()
    {

    }
}
