using System.Collections;
using TMPro;
using UnityEngine;

public class Missile : Projectile
{
    public MissileStats stats;

    public override void Shoot()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.linearVelocity = transform.forward * 3f;
        transform.rotation = Quaternion.Euler(0, RNG.rng.Next(-90, 90), 0);

        StartCoroutine(ArmMissile(stats.ArmingTime));
    }

    public override float GetDamage()
    {
        return stats.MissileDamage;
    }

    IEnumerator ArmMissile(float time)
    {
        yield return new WaitForSeconds(time);
        Launch();
    }

    public void Launch()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.linearVelocity = transform.forward * stats.MissileSpeed;
        StartCoroutine(DestroyAfterTime(stats.Lifetime));
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