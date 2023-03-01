using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{

    [SerializeField] private float centerOverlap;
    [SerializeField] private float damagePower;
    

    [SerializeField] private AudioSource swordAudioSource;
    [SerializeField] private AudioClip swingClip;
    [SerializeField] private AudioClip swordHitClip;

    [SerializeField] Animation swordAnim;

    [SerializeField] private float attackCD;
    [SerializeField] private float timeElapsed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TalkToNPC();
        SwordAttack();
        
        timeElapsed += Time.deltaTime;
    }

    public void TalkToNPC()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            var playerPos = transform.position;
            var playerDirection = transform.forward;
            var playerRotation = transform.rotation;

            //Use the OverlapBox to detect if there are any other colliders within this box area.
            //Use the GameObject's centre, half the size (as a radius) and rotation. This creates an invisible box around your GameObject.
            var hitColliders = Physics.OverlapBox(playerPos + centerOverlap * playerDirection, transform.localScale / 1, playerRotation);
            foreach (var collider in hitColliders)
            {
                print(collider.gameObject.name);
                if (collider.TryGetComponent(out NPCInteractable npcInteractable))
                {
                    if (npcInteractable == GameManager.Instance.getNPCToTalk() || !npcInteractable.getIsGiving() )
                    {
                        npcInteractable.Interact();
                    }
                }
                else if(collider.TryGetComponent(out ObjectInteractable objectInteractable))
                {
                    objectInteractable.Interact();
                }
            }
        }
    }

    public void SwordAttack()
    {
        if (Input.GetMouseButtonDown(0) && timeElapsed >= attackCD)
        {
            timeElapsed = 0f;

            swordAnim.Play();

            var playerPos = transform.position;
            var playerDirection = transform.forward;
            var playerRotation = transform.rotation;

            //Use the OverlapBox to detect if there are any other colliders within this box area.
            //Use the GameObject's centre, half the size (as a radius) and rotation. This creates an invisible box around your GameObject.
            var hitColliders = Physics.OverlapBox(playerPos + centerOverlap * playerDirection, transform.localScale / 2, playerRotation);
            bool hasHit = false;
            foreach (var collider in hitColliders)
            {
                //Debug.Log(collider);
                if (collider.TryGetComponent(out Character character))
                {
                    if (character.transform.root == transform) break;
                    
                    bool isDead = false;
                    Debug.Log("Sword attack");
                    isDead = character.TakeDamage(damagePower);
                    swordAudioSource.clip = swordHitClip;
                    swordAudioSource.Play();
                    hasHit = true;

                    if (isDead)
                    {
                        gameObject.GetComponent<Character>().AddXP();
                    }
                }
            }

            if (!hasHit)
            {
                swordAudioSource.clip = swingClip;
                swordAudioSource.Play();
            }
        }
    }

    public void setAttack(float damage)
    {
        damagePower = damage;
    }
}
