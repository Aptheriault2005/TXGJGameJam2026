using System.Collections;
using TMPro;
using UnityEngine;

public class Missile : Projectile
{
    public MissileStats stats;
    private bool isArmed = false;
    private GameObject target = null;
    private Rigidbody rb;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public override void Shoot()
    {
        AudioManager.PlayMissileSFX();
        rb.linearVelocity = transform.forward * 1f;
        //rb.angularVelocity = transform.forward * 1f;
        //transform.rotation = Quaternion.Euler(0, RNG.rng.Next(-90, 90), 0);

        StartCoroutine(ArmMissile(stats.ArmingTime));
    }

    public override float GetDamage()
    {
        if (!isArmed) return 0f;

        return stats.MissileDamage;
    }

    private void Update()
    {
        if (target != null)
        {
            Vector3 direction = target.transform.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(direction.normalized, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, stats.HomingStrength * stats.MissileSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0 );
            //Debug.Log($"Rotation : {transform.rotation.eulerAngles}");
            rb.linearVelocity = transform.forward * stats.MissileSpeed;
        }
    }

    IEnumerator ArmMissile(float time)
    {
        yield return new WaitForSeconds(time);
        Launch();
    }

    public void Launch()
    {
        GameObject nearest = null;
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("enemy"))
        {
            if (nearest == null)
            {
                nearest = enemy;
            }
            else if (
                Vector3.Distance(enemy.transform.position, gameObject.transform.position)
                < Vector3.Distance(nearest.transform.position, gameObject.transform.position))
            {
                nearest = enemy;
            }
        }

        if (nearest != null) 
        {
            //gameObject.transform.LookAt(nearest.transform);
            target = nearest;
        }

        isArmed = true;
        rb.linearVelocity = transform.forward * stats.MissileSpeed;
        //rb.angularVelocity = Vector3.zero;
        StartCoroutine(DestroyAfterTime(stats.Lifetime));
    }

    IEnumerator DestroyAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        DestroyEffect();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{gameObject} collides with {other.gameObject}");
        if (other.gameObject.tag == "enemy")
        {
            DestroyEffect();
        }
    }

    public void DestroyEffect()
    {
        if (stats.DestroyEffect != null && isArmed)
        {
            stats.DestroyEffect.Activate(transform.position);
        }

        Destroy(gameObject);
    }
}