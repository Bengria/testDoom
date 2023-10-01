using System.Collections;
using UnityEngine;

public class Lava : MonoBehaviour
{
    [SerializeField] private int damagePerSecond;

    private int oneSecond = 1;
    private Player player;
    private bool canDealDamage;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.TryGetComponent(out Player _player))
        {
            player = _player;
            canDealDamage = true;
            StartCoroutine(DealDamage());
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        canDealDamage = false;
    }

    private IEnumerator DealDamage()
    {
        while (canDealDamage)
        {
            player.DealDamage(damagePerSecond);
            yield return new WaitForSeconds(oneSecond);
        }
    }
}

