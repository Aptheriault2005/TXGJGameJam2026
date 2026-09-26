using UnityEngine;

[CreateAssetMenu]
public class BulletSplitEffect : DestroyEffect
{
    public ProjectileStats splitProjectileStats;
    public int count;

    public override void Activate(Vector3 position)
    {
        Debug.Log("Destroy effect");
        for (int i = 0; i < count; i++)
        {
            GameObject split = ProjectilesSingleton.instance.Spawn(splitProjectileStats.Prefab);
            System.Random rng = new();
            split.transform.position = position;
            split.transform.Rotate(Vector3.up, (float)rng.Next(-180, 180));

            split.GetComponent<Bullet>().stats = (BulletStats)splitProjectileStats;
            split.GetComponent<Bullet>().Shoot();
        }
    }
}