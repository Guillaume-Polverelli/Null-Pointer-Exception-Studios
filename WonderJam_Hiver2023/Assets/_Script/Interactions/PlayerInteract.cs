using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{

    [SerializeField] private float centerOverlap;
    [SerializeField] private float damagePower;

    [SerializeField] Animation swordAnim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TalkToNPC();
        SwordAttack();
        
    }

    public void TalkToNPC()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            float interactRange = 2f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliderArray)
            {
                print(collider.gameObject.name);
                if (collider.TryGetComponent(out NPCInteractable npcInteractable))
                {
                    print("E is clicked");
                    GetComponent<PlayerMovement>().setStopped(true);
                    npcInteractable.Interact();
                }
            }
        }
    }

    public void SwordAttack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            swordAnim.Play();
            var playerPos = transform.position;
            var playerDirection = transform.forward;
            var playerRotation = transform.rotation;

            //Use the OverlapBox to detect if there are any other colliders within this box area.
            //Use the GameObject's centre, half the size (as a radius) and rotation. This creates an invisible box around your GameObject.
            var hitColliders = Physics.OverlapBox(playerPos + centerOverlap * playerDirection, transform.localScale / 2, playerRotation);
            foreach (var collider in hitColliders)
            {
                //Debug.Log(collider);
                if (collider.TryGetComponent(out Character character))
                {
                    bool isDead = false;
                    Debug.Log("Sword attack");
                    isDead = character.TakeDamage(damagePower);
                    if (isDead)
                    {
                        gameObject.GetComponent<Character>().AddXP();
                    }
                }
            }
        }
    }
}
