using UnityEngine;

[CreateAssetMenu]
public class BulletStats : ScriptableObject
{
    public GameObject Prefab;
    public float BulletDamage = 5f;
    public float BulletSpeed = 10.0f;
    public float Lifetime = 2f;
    public DestroyEffect DestroyEffect;

    public BulletStats Copy()
    {
        BulletStats bs = CreateInstance<BulletStats>();
        bs.SetBulletSpeed(BulletSpeed);
        bs.SetLifetime(Lifetime);
        bs.SetDestroyEffect(DestroyEffect);
        bs.SetPrefab(Prefab);
        bs.SetBulletDamage(BulletDamage);
        return bs;

        //return new BulletStats(Prefab, BulletSpeed, Lifetime, DestroyEffect);
    }

    public BulletStats SetPrefab(GameObject prefab)
    {
        Prefab = prefab;
        return this;
    }

    public BulletStats SetBulletSpeed(float bulletSpeed)
    {
        BulletSpeed = bulletSpeed;
        return this;
    }

    public BulletStats SetBulletDamage(float bulletDamage)
    {
        BulletSpeed = bulletDamage;
        return this;
    }

    public BulletStats SetLifetime(float lifetime)
    {
        Lifetime = lifetime;
        return this;
    }

    public BulletStats SetDestroyEffect(DestroyEffect destroyEffect)
    {
        DestroyEffect = destroyEffect;
        return this;
    }
}