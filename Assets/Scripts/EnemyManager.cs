using System.Collections.Generic;
using UnityEngine;

public static class EnemyManager 
{
    static HashSet<Damageable> damageable = new HashSet<Damageable>();

    public static IReadOnlyCollection<Damageable> Enemies => damageable;

    public static void RegisterEnemy(Damageable _damageable)
    {
        damageable.Add(_damageable);
    }

    public static void UnregisterEnemy(Damageable _damageable)
    {
        damageable.Remove(_damageable);
    }

    public static Damageable GetFirstVisibleTarget(Transform sourceTransform)
    { 
        foreach (Damageable enemy in EnemyManager.Enemies)
        {
            Vector3 enemyDirection = enemy.transform.position - sourceTransform.position;
            enemyDirection.y = 0;

            enemyDirection = enemyDirection.normalized;

            float angle = Mathf.Acos(Vector3.Dot(sourceTransform.forward, enemyDirection)) * Mathf.Rad2Deg;

            if (angle < 3)
            {
                CapsuleCollider enemyCollider = enemy.GetComponent<CapsuleCollider>();

                Vector3 unitFrac = new Vector3(0, enemyCollider.height / 2);

                //raycast
                if (AimLineAttack(enemy.transform.position, sourceTransform)
                    || AimLineAttack(enemy.transform.position + unitFrac, sourceTransform)
                    || AimLineAttack(enemy.transform.position - unitFrac, sourceTransform))
                {
                    return enemy;
                }
            }
        }

       return null;
    }

    static private bool AimLineAttack(Vector3 targetPos, Transform sourceTransform)
    {
        if (Physics.Linecast(sourceTransform.position, targetPos, out RaycastHit hit)
                    && hit.collider.GetComponent<Damageable>())
        {
            Debug.DrawLine(sourceTransform.position, targetPos, Color.black);

            return true;
        }

        return false;
    }
}
