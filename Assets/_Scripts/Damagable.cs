using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Damagable : MonoBehaviour
{
    [SerializeField] protected int hp;
    protected bool isDead;
    protected int currentHp;

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

    public virtual void DealDamage(int damageAmount)
    {

    }

    protected virtual void Die()
    {
        Debug.Log($"{gameObject.name} is dead");
    }

    public virtual void Heal(GameObject hilca)
    {

    }

}
