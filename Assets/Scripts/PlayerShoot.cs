using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private UIAim aim;
    private void Update()
    {
        foreach (Shootable enemy in EnemyManager.Enemies)
        {
            Vector3 enemyDirection = enemy.transform.position - transform.position;
            enemyDirection.y = 0;

            enemyDirection = enemyDirection.normalized;

            float angle = Mathf.Acos(Vector3.Dot(transform.forward, enemyDirection)) * Mathf.Rad2Deg;

            if (angle < 3)
            {
                CapsuleCollider enemyCollider = enemy.GetComponent<CapsuleCollider>();

                Vector3 unitFrac = new Vector3(0, enemyCollider.height / 2);

                //raycast
                if (AimLineAttack(enemy.transform.position)
                    || AimLineAttack(enemy.transform.position + unitFrac)
                    || AimLineAttack(enemy.transform.position - unitFrac))
                {
                    aim.CanShoot = true;
                    return;
                }
            }
        }

        aim.CanShoot = false;
    }

    private bool AimLineAttack(Vector3 targetPos)
    {
        if (Physics.Linecast(transform.position, targetPos, out RaycastHit hit)
                    && hit.collider.GetComponent<Shootable>())
        {
            Debug.DrawLine(transform.position, targetPos, Color.black);

            return true;
        }

        return false;
    }
}
