using System;
using UnityEngine;

public class TrainCar : MonoBehaviour
{
    [SerializeField] private GameObject selectionIndicator;
    [SerializeField] private GameObject turretPivot;
    [SerializeField] private GameObject bulletSpawnPoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private BulletStats bulletStats;

    private bool isSelected = false;
    private ITrainCarAbility trainCarAbility;

    void Awake()
    {
        trainCarAbility = new MachineGunAbility(bulletStats);
    }

    public void MousePositionUpdate(GameObject mousePosIndicator)
    {
        if (isSelected)
        {
            turretPivot.transform.LookAt(mousePosIndicator.transform);
            turretPivot.transform.rotation = Quaternion.Euler(0, turretPivot.transform.rotation.eulerAngles.y, 0);
        }
    }

    public void UseTrainCarAbility()
    {
        trainCarAbility.UseAbility(this);
    }

    public void SelectTrainCar() 
    {
        isSelected = true;
        selectionIndicator.SetActive(true);
    }

    public void DeselectTrainCar() 
    {
        isSelected = false;
        selectionIndicator.SetActive(false);
    }

    public GameObject GetProjectilePrefab()
    {
        return bulletPrefab;
    }

    public GameObject GetProjectileSpawnPoint() { return bulletSpawnPoint; }
}

public interface ITrainCarAbility
{
    public void UseAbility(TrainCar trainCar);
}

public class MachineGunAbility : ITrainCarAbility
{
    BulletStats BulletStats;

    public MachineGunAbility(BulletStats bulletStats)
    {
        BulletStats = bulletStats;
    }

    public void UseAbility(TrainCar trainCar)
    {
        Debug.Log($"{trainCar.gameObject.name} train car abilty used");
        GameObject bullet = ProjectilesSingleton.instance.Spawn(trainCar.GetProjectilePrefab());
        bullet.gameObject.transform.position = trainCar.GetProjectileSpawnPoint().transform.position;
        bullet.gameObject.transform.rotation = trainCar.GetProjectileSpawnPoint().transform.rotation;
        bullet.GetComponent<Bullet>().Shoot(BulletStats);
    }
}
