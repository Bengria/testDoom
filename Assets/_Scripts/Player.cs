using UnityEngine;

public class Player : Damagable, IHealable
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

    public void Heal(GameObject hilca)
    {
        if (currentHp < hp)
            Destroy(hilca);

        if (currentHp <= hp - 20 & currentHp > 0)
            currentHp += 20;

        if (currentHp > hp - 20)
            currentHp = 100;
    }
}
