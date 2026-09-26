using UnityEngine;

[CreateAssetMenu]
public class MissileStats : ProjectileStats
{
    public float MissileDamage = 5f;
    public float MissileSpeed = 10.0f;
    public float ArmingTime = 0.5f;
    public float Lifetime = 2f;

    public MissileStats Copy()
    {
        MissileStats ms = CreateInstance<MissileStats>();
        ms.SetPrefab(Prefab);
        ms.SetMissileSpeed(MissileSpeed);
        ms.SetMissileDamage(MissileDamage);
        ms.SetArmingTime(ArmingTime);
        ms.SetLifetime(Lifetime);
        ms.SetDestroyEffect(DestroyEffect);
        return ms;
    }

    public MissileStats SetPrefab(GameObject prefab)
    {
        Prefab = prefab;
        return this;
    }

    public MissileStats SetMissileSpeed(float missleSpeed)
    {
        MissileSpeed = missleSpeed;
        return this;
    }

    public MissileStats SetMissileDamage(float missileDamage)
    {
        MissileDamage = missileDamage;
        return this;
    }

    public MissileStats SetArmingTime(float armingTime)
    {
        ArmingTime = armingTime;
        return this;
    }

    public MissileStats SetLifetime(float lifetime)
    {
        Lifetime = lifetime;
        return this;
    }

    public MissileStats SetDestroyEffect(DestroyEffect destroyEffect)
    {
        DestroyEffect = destroyEffect;
        return this;
    }
}