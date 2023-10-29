using System;
using UnityEngine;

public class Player : Damageable
{ 
    public bool TryHeal(int amountToHeal)
    {
        if (currentHp < maxHP)
        {
           currentHp += Mathf.Clamp(amountToHeal, 0, maxHP - currentHp);
           return true;
        }
        else
        {
            return false;
        }
    }
}