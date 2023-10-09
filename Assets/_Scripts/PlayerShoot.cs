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

            aim.CanShoot = angle < 3;
        }
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit) && hit.collider.TryGetComponent(out Shootable shootable))
        {
            Debug.Log("Shoot");

        }
    }
}
