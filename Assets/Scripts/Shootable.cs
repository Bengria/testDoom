using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootable : Damagable
{
    protected virtual void OnEnable()
    {
        EnemyManager.RegisterEnemy(this);
    }

    protected virtual void OnDisable()
    {
        EnemyManager.UnregisterEnemy(this);
    }
}
