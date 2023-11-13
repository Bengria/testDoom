using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private UIAim aim;

    private void Update()
    {
        Damageable damageable 
            = EnemyManager.GetFirstVisibleTarget(transform, 3, Affiliation.Demon | Affiliation.Neutral, 30);

        aim.CanShoot = damageable != null;
    }
}