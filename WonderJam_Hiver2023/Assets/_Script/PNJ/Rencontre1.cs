using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rencontre1 : MonoBehaviour
{
    [SerializeField] BoxCollider boxCollider;
    [SerializeField] private int idRencontre;
    private bool dialogEnabled = false;


    public void Update()
    {
        if (gameObject.GetComponent<Character>().getHP() <= 0)
        {
            switch (idRencontre)
            {
                case (0):
                    GameManager.Instance.EndQuest_2();
                    break;
                case (1):
                    GameManager.Instance.EndRencontre_2();
                    break;
                case (2):
                    GameManager.Instance.EndRencontre_3();
                    break;

            }
            
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerInteract player) && !dialogEnabled)
        {
            gameObject.GetComponent<NPCInteractable>().Interact();
            dialogEnabled = true;
            Vector3 targetPosition = new Vector3(gameObject.transform.position.x,
                                                  other.transform.position.y,
                                                  gameObject.transform.position.z);
            other.transform.LookAt(targetPosition);
            boxCollider.enabled = false;
        }
       
    }
}
