using System.Collections;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class Projectile : MonoBehaviour
{
    public abstract void Shoot();

    public abstract float GetDamage();

    public void ShootProjectile(GameObject projectile, ProjectileStats stats)
    {
        if (stats is BulletStats bulletStats)
        {
            projectile.GetComponent<Bullet>().stats = bulletStats;
            projectile.GetComponent<Bullet>().Shoot();
        }
        else if (stats is MissileStats missileStats)
        {
            projectile.GetComponent<Missile>().stats = missileStats;
            projectile.GetComponent<Missile>().Shoot();
        }
        else if (stats is ElectricChargeStats electricChargeStats)
        {
            projectile.GetComponent<ElectricCharge>().stats = electricChargeStats;
            projectile.GetComponent<ElectricCharge>().Shoot();
        }
        else if (stats is ExplosionStats explosionStats) 
        {
            projectile.GetComponent<Explosion>().stats = explosionStats;
            projectile.GetComponent<Explosion>().Shoot();
        }
    }
}