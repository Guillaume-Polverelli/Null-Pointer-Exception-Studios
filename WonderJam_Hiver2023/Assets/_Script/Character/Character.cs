using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    [SerializeField] private float maxHP;
    [SerializeField] private float maxXP;
    [SerializeField] private float XP;
    [SerializeField] private GameObject progressBarHP;
    [SerializeField] private GameObject progressBarXP;
    [SerializeField] private int regenValue;
    [SerializeField] private float regenCooldown;


    private float HP;
    private float timeCounter = 0f;
    public void Start()
    {
        HP = maxHP;
    }

    public void Update()
    {
        progressBarHP.GetComponent<Image>().fillAmount =  (HP / maxHP);
        progressBarXP.GetComponent<Image>().fillAmount =  (XP / maxXP);

    }

    public void FixedUpdate()
    {
        if(timeCounter < regenCooldown)
        {
            timeCounter += Time.fixedDeltaTime;
        }
        else if(HP < maxHP)
        {
            Regen(regenValue);
            timeCounter = 0f;
        }
        else if(timeCounter != 0f)
        {
            timeCounter = 0f;
        }
    }


    public void TakeDamage(float damage)
    {
        HP -= damage;
        if(HP <= 0f)
        {
            Die();
        }
    }

    public void Regen(int value)
    {
        HP += value;
        if(HP > maxHP)
        {
            HP = maxHP;
        }
    }

    public void Die()
    {
        gameObject.SetActive(false);
        //Destroy(gameObject);
    }
}
