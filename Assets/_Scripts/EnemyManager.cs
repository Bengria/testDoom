using System.Collections.Generic;

public static class EnemyManager 
{
    static HashSet<Damagable> damagables = new HashSet<Damagable>();

    public static IReadOnlyCollection<Damagable> Enimies => damagables;

    public static void RegisterEnemy(Damagable damagable)
    {
        damagables.Add(damagable);
    }

    public static void UnregisterEnemy(Damagable damagable)
    {
        damagables.Remove(damagable);
    }
}
