using UnityEngine;

public class Lava : MonoBehaviour
{
    [SerializeField] private int damagePerSecond;
    public int DamagePerSecond => damagePerSecond;
    private Player player;
    private float timer;

    private void OnCharacterStay(PlayerController playerController)
    {
        timer += Time.deltaTime;

        if (timer >= 1)
        {
            DealDamage();
            timer = 0;
        }
    }

    private void DealDamage()
    {
        player.DealDamage(damagePerSecond);
    }

    private void OnCharacterEnter(PlayerController playerController)
    {
        player = playerController.GetComponent<Player>();
    }

    private void OnCharacterExit(PlayerController playerController)
    {
        timer = 0;
    }
}
