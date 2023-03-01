using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManagaer : MonoBehaviour
{
    [SerializeField] private GameObject creditWindow;

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
        creditWindow.SetActive(true);
    }

    public void BackMenu()
    {
        creditWindow.SetActive(false);
    }
}
