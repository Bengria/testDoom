using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingComponent : MonoBehaviour
{
    [SerializeField] private int amountToHeal;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out Player player))
        {
            player.TryHeal(amountToHeal, out bool isPickedUp);

            if (isPickedUp)
            {
                Destroy(gameObject);
            }
        }

    }
}
