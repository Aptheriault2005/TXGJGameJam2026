using UnityEngine;

[CreateAssetMenu]
public class BulletStats : ProjectileStats
{
    public float BulletDamage = 5f;
    public float BulletSpeed = 10.0f;
    public float Lifetime = 2f;
    public int BulletPierceCount = 0;

    public BulletStats Copy()
    {
        BulletStats bs = CreateInstance<BulletStats>();
        bs.SetBulletSpeed(BulletSpeed);
        bs.SetLifetime(Lifetime);
        bs.SetDestroyEffect(DestroyEffect);
        bs.SetPrefab(Prefab);
        bs.SetBulletDamage(BulletDamage);
        bs.SetBulletPierceCount(BulletPierceCount);
        return bs;
    }

    public BulletStats SetBulletPierceCount(int i)
    {
        BulletPierceCount = i;
        return this;
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