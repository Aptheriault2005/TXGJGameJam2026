using UnityEngine;

[CreateAssetMenu]
public class ExplosionStats : ProjectileStats
{
    public float ExplosionRadius;
    public float ExplosionDamage;

    public ExplosionStats Copy()
    {
        ExplosionStats es = CreateInstance<ExplosionStats>();
        es.SetExplosionDamage(ExplosionDamage); ;
        es.SetExplosionRadius(ExplosionRadius);
        return es;
    }

    public ExplosionStats SetExplosionRadius(float value)
    {
        ExplosionRadius = value;
        return this;
    }

    public ExplosionStats SetExplosionDamage(float value)
    {
        ExplosionDamage = value;
        return this;
    }
}