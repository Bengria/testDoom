using System;
using UnityEngine;

public class Player : Damagable
{ 
    public override void DealDamage(int damageAmount)
    {
        currentHp -= damageAmount;
        if (currentHp <= 0 )
        {
            currentHp = 0;
            Die();
        }
    }

    public void TryHeal(int amountToHeal, out bool isPickedUp)
    {
        if (currentHp < maxHP)
        {
           currentHp += Mathf.Clamp(amountToHeal, 0, maxHP - currentHp);
           isPickedUp = true;
        }
        else
        {
            isPickedUp = false;
        }
    }
}
