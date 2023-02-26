using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Character : MonoBehaviour
{
    [SerializeField] private float maxHP;
    [SerializeField] private float maxXP;
    [SerializeField] private float XP;
    [SerializeField] private GameObject progressBarHP;
    [SerializeField] private GameObject progressBarXP;
    [SerializeField] private int regenValue;
    [SerializeField] private float regenCooldown;
    [SerializeField] private TMP_Text level;
    [SerializeField] private SceneFinale finalScene;


    private float HP;
    private float timeCounter = 0f;
    public void Start()
    {
        HP = maxHP;
    }

    public void Update()
    {
        if (progressBarHP == null || progressBarXP == null) return;
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


    public bool TakeDamage(float damage)
    {
        HP -= damage;
        if(HP <= 0f)
        {
            Die();
            return true;
        }
        return false;
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
        if (gameObject.GetComponent<Tonmou_Behavior>())
        {
            gameObject.GetComponent<Tonmou_Behavior>().Die();
        }
        else if (gameObject.GetComponent<NPC_Behavior>())
        {
            gameObject.GetComponent<NPC_Behavior>().Die();

        }
        else
        {
            finalScene.Init();



        }

        //gameObject.SetActive(false);
        //Destroy(gameObject);
    }

    public void AddXP()
    {
        XP += 1f;
        if(XP >= maxXP)
        {
            XP = 0;
            GameManager.Instance.TriggerLocker_0();
            level.SetText("Lvl 000");
        }
    }

    public float getHP()
    {
        return HP;
    }
}
