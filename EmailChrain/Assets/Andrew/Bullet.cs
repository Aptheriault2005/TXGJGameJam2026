using System.Collections;
using UnityEngine;

public class Bullet : Projectile
{
    public BulletStats stats;
    private int pierceCount = 0;

    public override void Shoot()
    {
        AudioManager.PlayBulletSFX();
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

    IEnumerator DisableInvAfter(float time)
    {
        yield return new WaitForSeconds(time);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log($"{gameObject} collides with {other.gameObject}");
        if (other.gameObject.tag == "enemy")
        {
            if (pierceCount < stats.BulletPierceCount)
            {
                pierceCount++;
            }
            else
            {
                DestroyEffect();
            }
        }
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