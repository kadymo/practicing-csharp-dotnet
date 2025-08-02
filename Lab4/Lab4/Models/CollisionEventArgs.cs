namespace Lab4.Models;

public class CollisionEventArgs
{
    public GameObject ProjectileGameObject { get; set; }
    public GameObject EnemyGameObject { get; set; }

    public CollisionEventArgs(GameObject projectileGameObject, GameObject enemyGameObject)
    {
        ProjectileGameObject = projectileGameObject;
        EnemyGameObject = enemyGameObject;
    }
}
