using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hilingable : MonoBehaviour
{

    public void Heal(GameObject hilca)
    {
        int hp = gameObject.GetComponent<Damagable>().Hp;
        int maxHp = gameObject.GetComponent<Character>().Hp;

        if (hp < maxHp)
            Destroy(hilca);

        if (hp <= maxHp - 20 & hp > 0)
            hp += 20;

        if (hp > maxHp - 20)
            hp = 100;

        gameObject.GetComponent<Damagable>().Hp = hp;
    }
}
