using UnityEngine;

public class Player : Damagable, IHealable
{
    [SerializeField] private int maxHp = 100;

    public void Heal(GameObject hilca)
    {
        if (currentHp < maxHp)
            Destroy(hilca);

        if (currentHp <= maxHp - 20 & currentHp > 0)
            currentHp += 20;

        if (currentHp > maxHp - 20)
            currentHp = 100;
    }
}
