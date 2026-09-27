using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Turret : MonoBehaviour
{
    [SerializeField] private GameObject turretPivot;
    [SerializeField] private GameObject turretModelSpawnPos;
    [SerializeField] private GameObject bulletSpawnPoint;
    public TurretStats turretStats;

    private GameObject turretModel = null;
    private ITrainCarAbility trainCarAbility;
    private bool isAbilityActive = false;
    private float timeSinceLastUse = float.MaxValue;
    private System.Random rng;

    void Awake()
    {
        rng = new();

        turretStats = turretStats.Copy();
        trainCarAbility = new ProjectileAbility(turretStats.ProjectileStats, this);
    }

    private void Update()
    {
        timeSinceLastUse += Time.deltaTime;

        if (isAbilityActive) 
        {
            if (timeSinceLastUse >= turretStats.FireRate) 
            {
                timeSinceLastUse = 0;
                bulletSpawnPoint.transform.localRotation = Quaternion.identity;
                bulletSpawnPoint.transform.Rotate(0f, (float)rng.Next(-turretStats.ProjectileSpray, turretStats.ProjectileSpray), 0f);
                trainCarAbility.UseAbility();
            }
        }
    }

    public void SetTurretAbility(TurretStats turretStats)
    {
        this.turretStats = turretStats;
        if (turretModel == null)
        {
            turretModel = Instantiate(turretStats.TurretModelPrefab, turretModelSpawnPos.transform);
        }
        else
        {
            Destroy(turretModel);
            turretModel = Instantiate(turretStats.TurretModelPrefab, turretModelSpawnPos.transform);
        }
        trainCarAbility = new ProjectileAbility(turretStats.ProjectileStats, this);
    }

    public void StartTurretAbility()
    {
        isAbilityActive = true;
    }

    public void StopTurretAbility()
    {
        isAbilityActive = false;
    }

    public void MoveTurret(Transform lookAtTransform)
    {
        transform.LookAt(lookAtTransform);
        turretPivot.transform.rotation = Quaternion.Euler(0, turretPivot.transform.rotation.eulerAngles.y, 0);
    }

    public GameObject GetProjectilePrefab()
    {
        return turretStats.ProjectileStats.Prefab;
    }

    public GameObject GetProjectileSpawnPoint() 
    {
        return bulletSpawnPoint; 
    }
}

public interface ITrainCarAbility
{
    public void UseAbility();
}

public class ProjectileAbility : ITrainCarAbility
{
    public Turret Turret;
    public ProjectileStats ProjectileStats;

    public ProjectileAbility(ProjectileStats projectileStats, Turret turret)
    {
        Turret = turret;
        ProjectileStats = projectileStats;
    }

    public void UseAbility()
    {
        //Debug.Log($"{Turret.gameObject.name} train car abilty used");
        GameObject projectile = ProjectilesSingleton.instance.Spawn(Turret.GetProjectilePrefab());
        projectile.gameObject.transform.position = Turret.GetProjectileSpawnPoint().transform.position;
        projectile.gameObject.transform.rotation = Turret.GetProjectileSpawnPoint().transform.rotation;

        projectile.GetComponent<Projectile>().ShootProjectile(projectile, ProjectileStats);

        //if (ProjectileStats is BulletStats bulletStats)
        //{
        //    projectile.GetComponent<Bullet>().stats = bulletStats;
        //    projectile.GetComponent<Bullet>().Shoot();
        //}
        //else if (ProjectileStats is MissileStats missileStats)
        //{
        //    projectile.GetComponent<Missile>().stats = missileStats;
        //    projectile.GetComponent<Missile>().Shoot();
        //}
        //else if (ProjectileStats is ElectricChargeStats electricChargeStats)
        //{
        //    projectile.GetComponent<ElectricCharge>().stats = electricChargeStats;
        //    projectile.GetComponent <ElectricCharge>().Shoot();
        //}
    }
}
