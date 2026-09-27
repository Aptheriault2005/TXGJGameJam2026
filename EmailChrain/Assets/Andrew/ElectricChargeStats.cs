using UnityEngine;

[CreateAssetMenu]
public class ElectricChargeStats : ProjectileStats
{
    public float ChargeDamage;
    public float ChargeRadius;
    public int JumpCount = 2;

    public ElectricChargeStats Copy()
    {
        ElectricChargeStats es = CreateInstance<ElectricChargeStats>();
        es.SetDestroyEffect(DestroyEffect);
        es.SetPrefab(Prefab);
        es.SetChargeRadius(ChargeRadius);
        es.SetJumpCount(JumpCount);
        return es;
    }

    public ElectricChargeStats SetChargeDamage(float damage)
    {
        ChargeDamage = damage;
        return this;
    }

    public ElectricChargeStats SetChargeRadius(float chargeRadius)
    {
        this.ChargeRadius = chargeRadius;
        return this;
    }

    public ElectricChargeStats SetJumpCount(int jumpCount)
    {
        this.JumpCount = jumpCount;
        return this;
    }

    public ElectricChargeStats SetPrefab(GameObject prefab)
    {
        Prefab = prefab;
        return this;
    }

    public ElectricChargeStats SetDestroyEffect(DestroyEffect destroyEffect)
    {
        DestroyEffect = destroyEffect;
        return this;
    }
}