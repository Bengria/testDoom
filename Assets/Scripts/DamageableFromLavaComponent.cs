using UnityEngine;

[RequireComponent(typeof(Damagable), typeof(ObjecUnderChecker))]
public class DamageableFromLavaComponent : MonoBehaviour
{
    private int damagePerSecond;
    private Damagable damagable;
    private int oneSecond = 1;
    private float timer;
    private bool isOnLava;

    private void Awake()
    {
        damagable = GetComponent<Damagable>();
    }

    private void Start()
    {
        GetComponent<ObjecUnderChecker>().OnSteppingNewSurfaceEvent += CheckIfOnLava;
    }

    void Update()
    {
        if (isOnLava)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
        }

        if (timer >= oneSecond)
        {
            TakeDamage(damagable);
            timer = 0;
        }
    }

    private void CheckIfOnLava(GameObject surfaceUnder)
    {
        if (surfaceUnder.TryGetComponent(out Lava lava))
        {
            damagePerSecond = lava.DamagePerSecond;
            isOnLava = true;
        }
        else
        {
            isOnLava = false;
        }
    }

    private void TakeDamage(Damagable player)
    {
        player.DealDamage(damagePerSecond);
    }
}

