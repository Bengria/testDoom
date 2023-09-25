using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagebleComponent : MonoBehaviour
{
    [SerializeField] private int hp = 100;

    int currentHp;

    bool isDead;

    private void Start()
    {
        currentHp = hp;
    }

    public bool IsDead => isDead;

    public bool IsAlive => !isDead;

    public int Hp
    {
        get => hp;
        set
        {
            if (isDead)
                return;

            currentHp = value;

            if (currentHp <= 0)
            {
                Die();
            }
        }
    }
    void Die()
    {
        Debug.Log($"{gameObject.name} is dead");
        isDead = true;
    }
    //public void DealDamage(int damageAmount)
    //{

    //}
    //public void Heal()
    //{
        //if (isDead)
           // return;
    //}
}
