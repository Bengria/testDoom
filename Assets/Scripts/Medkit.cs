using UnityEngine;

public class Medkit : MonoBehaviour
{
    [SerializeField] private int amountToHeal;
    [SerializeField] private Affiliation healAffiliation;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out Damageable damageable) &&
            (damageable.Affiliation & healAffiliation) > 0)
        {
            if (damageable.TryHeal(amountToHeal))
            {
                PickedUp();
            }
        }
    }

    private void PickedUp()
    {
        Destroy(gameObject);
    }
}