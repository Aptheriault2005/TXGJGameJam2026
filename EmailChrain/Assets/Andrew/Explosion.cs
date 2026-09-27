using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Explosion : Projectile
{
    public ExplosionStats stats;
    private HashSet<GameObject> HitEnemies = new();

    public override void Shoot()
    {
        transform.localScale = Vector3.one * stats.ExplosionRadius;
        StartCoroutine(DestroyAfterTime(0.1f));
    }

    public override float GetDamage()
    {
        return stats.ExplosionDamage;
    }

    IEnumerator DestroyAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        DestroyEffect();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{gameObject} collides with {other.gameObject}");

        if (HitEnemies.Contains(other.gameObject)) return;

        HitEnemies.Append(other.gameObject);
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