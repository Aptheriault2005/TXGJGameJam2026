using System;
using UnityEngine;

public class TrainCar : MonoBehaviour
{
    [SerializeField] private GameObject selectionIndicator;
    [SerializeField] private Turret turret;

    private bool isSelected = false;

    public void MousePositionUpdate(GameObject mousePosIndicator)
    {
        if (isSelected)
        {
            turret.MoveTurret(mousePosIndicator.transform);
        }
    }

    public void UseTrainCarAbility()
    {
        turret.StartTurretAbility();
    }

    public void StopTrainCarAbility()
    {
        turret.StopTurretAbility();
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
        turret.StopTurretAbility();
    }
}

//public interface ITrainCarAbility
//{
//    public void UseAbility(TrainCar trainCar);
//}

//public class MachineGunAbility : ITrainCarAbility
//{
//    BulletStats BulletStats;

//    public MachineGunAbility(BulletStats bulletStats)
//    {
//        BulletStats = bulletStats;
//    }

//    public void UseAbility(TrainCar trainCar)
//    {
//        Debug.Log($"{trainCar.gameObject.name} train car abilty used");
//        GameObject bullet = ProjectilesSingleton.instance.Spawn(trainCar.GetProjectilePrefab());
//        bullet.gameObject.transform.position = trainCar.GetProjectileSpawnPoint().transform.position;
//        bullet.gameObject.transform.rotation = trainCar.GetProjectileSpawnPoint().transform.rotation;
//        bullet.GetComponent<Bullet>().Shoot(BulletStats);
//    }
//}
