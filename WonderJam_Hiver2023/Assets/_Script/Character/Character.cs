using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private int HP;
    [SerializeField] private int XP;

    [SerializeField] private int attack;

    public void TakeDamage(int damage)
    {
        HP -= damage;
        if(HP <= 0)
        {
            Die();
        }
    }

    public void Attack()
    {
        
    }

    public void Die()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
