using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagable : MonoBehaviour
{
    [SerializeField] private int hp = 100;

    private bool isDead;
    private int currentHp;

    private void Start()
    {
        currentHp = hp;
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

    public void Heal(GameObject hilca)
    {
        if (hp < 100)
            Destroy(hilca);

        if (hp <= 80 & IsAlive) 
            hp += 20;

        if (hp > 80) 
            hp = 100;
    }
}
