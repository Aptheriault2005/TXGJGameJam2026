using UnityEngine;

[CreateAssetMenu]
public class BulletSplitEffect : DestroyEffect
{
    public GameObject prefab;
    public int count;

    public override void Activate(Bullet bullet)
    {
        Debug.Log("Destroy effect");
        for (int i = 0; i < count; i++)
        {
            GameObject split = ProjectilesSingleton.instance.Spawn(prefab);
            System.Random rng = new();
            split.transform.position = bullet.transform.position;
            split.transform.Rotate(Vector3.up, (float)rng.Next(-180, 180));

            BulletStats splitBulletStats = bullet.stats.Copy().SetDestroyEffect(null);

            split.GetComponent<Bullet>().Shoot(splitBulletStats);
        }
    }
}