using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFinale : MonoBehaviour
{

    [SerializeField] private GameObject blood;
    [SerializeField] private NPCInteractable hero;
    [SerializeField] private Character player;
    [SerializeField] private GameObject chatMessage;
    [SerializeField] private GameObject playerCamera;
    [SerializeField] private GameObject heroCamera;
    public void Init()
    {
        player.setHealth(100f, 0f);
        blood.SetActive(true);
        hero.Interact();
    }

    public void RemoveAnim()
    {
        blood.SetActive(false);
        hero.Interact();
    }

    public void HeroHasLeftGame()
    {
        hero.GetComponent<Animator>().enabled = false;
        chatMessage.SetActive(true);
        hero.Interact();
    }

    public void FinishTheGame()
    {
        playerCamera.SetActive(false);
        heroCamera.SetActive(true);
        Invoke("LoadEndLevel", 3.0f);
    }

    public void LoadEndLevel()
    {
        SceneManager.LoadScene(0);
    }
}
