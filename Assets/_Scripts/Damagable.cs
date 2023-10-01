using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagable : MonoBehaviour
{
    private bool isDead;
    private int currentHp;

    private void Start()
    {
        currentHp = gameObject.GetComponent<Character>().Hp;
    }

    public bool IsDead => isDead;
    public bool IsAlive => !isDead;


    public int Hp
    {
        get => currentHp;
        set
        {
            if (isDead) return;

            currentHp = value;

            if (currentHp <= 0)
            {
                currentHp = 0;
                Die();
            }
        }
    }

    public void DealDamage(int damageAmount)
    {

    }

    private void Die()
    {
        Debug.Log($"{gameObject.name} is dead");
    }

}
