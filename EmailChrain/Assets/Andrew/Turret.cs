using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private GameObject turretPivot;
    [SerializeField] private GameObject bulletSpawnPoint;
    [SerializeField] private TurretStats turretStats;

    private ITrainCarAbility trainCarAbility;
    private bool isAbilityActive = false;
    private float timeSinceLastUse = float.MaxValue;
    private System.Random rng;

    void Awake()
    {
        rng = new();
        trainCarAbility = new MachineGunAbility(turretStats.BulletStats, this);
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
                bulletSpawnPoint.transform.Rotate(0f, (float)rng.Next(-turretStats.BulletSpray, turretStats.BulletSpray), 0f);
                trainCarAbility.UseAbility();
            }
        }
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
        return turretStats.BulletStats.Prefab;
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

public class MachineGunAbility : ITrainCarAbility
{
    public Turret Turret;
    public BulletStats BulletStats;

    public MachineGunAbility(BulletStats bulletStats, Turret turret)
    {
        BulletStats = bulletStats;
        Turret = turret;
    }

    public void UseAbility()
    {
        Debug.Log($"{Turret.gameObject.name} train car abilty used");
        GameObject bullet = ProjectilesSingleton.instance.Spawn(Turret.GetProjectilePrefab());
        bullet.gameObject.transform.position = Turret.GetProjectileSpawnPoint().transform.position;
        bullet.gameObject.transform.rotation = Turret.GetProjectileSpawnPoint().transform.rotation;
        bullet.GetComponent<Bullet>().Shoot(BulletStats);
    }
}
