using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit) && hit.collider.TryGetComponent(out Damagable damagable))
        {
            Debug.Log("Shoot");

            foreach(Damagable enemy in EnemyManager.Enimies)
            {
                Vector3 enemyDirection = (enemy.transform.position - transform.position).normalized;

                print(Vector3.Dot(transform.forward, enemyDirection));
            }
        }
    }
}
