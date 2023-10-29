using System.Collections.Generic;

public static class EnemyManager 
{
    static HashSet<Shootable> shootables = new HashSet<Shootable>();

    public static IReadOnlyCollection<Shootable> Enemies => shootables;

    public static void RegisterEnemy(Shootable shootable)
    {
        shootables.Add(shootable);
    }

    public static void UnregisterEnemy(Shootable shootable)
    {
        shootables.Remove(shootable);
    }
}
