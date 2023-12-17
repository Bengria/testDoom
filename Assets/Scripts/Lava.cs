using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    [SerializeField] private int damagePerSecond;
    [SerializeField] private Affiliation targetAffiliation;

    private Dictionary<Damageable, IEnumerator> damageableList = new Dictionary<Damageable, IEnumerator>();
    private Damageable targetDamageable;
    public int DamagePerSecond => damagePerSecond;

    private void DealDamage()
    {

        targetDamageable.DealDamage(damagePerSecond);
    }

    private void OnCharacterEnter(BaseCharacterController characterController)
    {
        if (characterController.TryGetComponent(out Damageable damageable) &&
            (damageable.Affiliation & targetAffiliation) > 0)
        {
            IEnumerator damageRoutine;
            StartCoroutine(damageRoutine = ContiniousDamage(damageable));
            damageableList.Add(damageable, damageRoutine);
        }
    }

    private void OnCharacterExit(BaseCharacterController characterController)
    {
        if (characterController.TryGetComponent(out Damageable damageable)
            && damageableList.ContainsKey(damageable))
        {
            IEnumerator damageRoutine = damageableList[damageable];
            damageableList.Remove(damageable);

            StopCoroutine(damageRoutine);
        }
    }

    private IEnumerator ContiniousDamage(Damageable damageable)
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            damageable.Hp -= damagePerSecond;
        }
    }
}
