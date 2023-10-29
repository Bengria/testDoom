using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Damageable : MonoBehaviour
{
    [SerializeField] protected int maxHP;
    protected bool isDead;
    protected int currentHp;

    private void Start()
    {
        currentHp = maxHP;
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

    public virtual void DealDamage(int damageAmount)
    {
        Hp -= damageAmount;
    }

    protected virtual void Die()
    {
        Debug.Log($"{gameObject.name} is dead");
    }

    public virtual void Heal(int amount)
    {

    }
}
