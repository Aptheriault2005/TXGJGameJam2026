using System;
using System.Collections;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    public BulletStats stats;

    public void Shoot(BulletStats bulletStats)
    {
        stats = bulletStats;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.linearVelocity = transform.forward * bulletStats.BulletSpeed;
        StartCoroutine(DestroyAfterTime(bulletStats.Lifetime));
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
            stats.DestroyEffect.Activate(this);
        }

        Destroy(gameObject);
    }
}