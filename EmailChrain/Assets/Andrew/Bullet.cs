using System;
using System.Collections;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : Projectile
{
    public BulletStats stats;

    public override void Shoot()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.linearVelocity = transform.forward * stats.BulletSpeed;
        StartCoroutine(DestroyAfterTime(stats.Lifetime));
    }

    public override float GetDamage()
    {
        return stats.BulletDamage;
    }

    IEnumerator DestroyAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        DestroyEffect();
    }

    private void OnCollisionEnter(Collision collision)
    {
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