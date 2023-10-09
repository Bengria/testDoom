using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private UIAim aim;
    void Update()
    {
        foreach (Shootable enemy in EnemyManager.Enimies)
        {
            Vector3 enemyDirection = enemy.transform.position - transform.position;
            enemyDirection.y = 0;
            enemyDirection = enemyDirection.normalized;

            float angle = Mathf.Acos(Vector3.Dot(transform.forward, enemyDirection)) * Mathf.Rad2Deg;

            if (angle < 3)
            {
                aim.CanShoot = angle < 3;
                return;
            }
        }

        aim.CanShoot = false;
    }
}
