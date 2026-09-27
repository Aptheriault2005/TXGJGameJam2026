using System.Collections;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class ElectricCharge : Projectile
{
    public ElectricChargeStats stats;
    public GameObject ignoredEnemy;

    public override float GetDamage()
    {
        return stats.ChargeDamage;
    }

    public override void Shoot()
    {
        transform.localScale = Vector3.one * stats.ChargeRadius;
        StartCoroutine(DestroyAfterTime(0.1f));
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log($"{gameObject} collides with {other.gameObject}");
        if (other.gameObject.tag == "enemy" && !other.Equals(ignoredEnemy))
        {
            if (stats.JumpCount > 0)
            {
                GameObject chargeObject = ProjectilesSingleton.instance.Spawn(stats.Prefab);
                chargeObject.transform.position = other.gameObject.transform.position;
                ElectricCharge charge = chargeObject.GetComponent<ElectricCharge>();
                charge.ignoredEnemy = other.gameObject;
                charge.stats = stats.Copy().SetJumpCount(stats.JumpCount - 1);
                charge.Shoot();
                DestroyEffect();
            }
        }
    }

    IEnumerator DestroyAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        DestroyEffect();
    }

    public void DestroyEffect()
    {
        if (stats.DestroyEffect != null)
        {
            stats.DestroyEffect.Activate(transform.position);
        }

        Destroy(gameObject);
    }
}