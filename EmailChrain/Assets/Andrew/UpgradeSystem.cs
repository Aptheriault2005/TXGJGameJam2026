using System.Collections.Generic;
using UnityEngine;

public static class UpgradeSystem
{
    public static Upgrade CreateNewTrainCarUpgrade(Train train, List<TurretStats> turrets, int index)
    {
        Upgrade upgrade = new Upgrade();
        TurretStats newTurret = turrets[index];
        upgrade.upgrade = Upgrade.UpgradeType.NewTrainCar;
        upgrade.train = train;
        upgrade.name = $"New train car: {newTurret.Name}";
        upgrade.description = $"Add a {newTurret.Name} to the end of your train";
        upgrade.turretStats = newTurret;
        upgrade.trainCar = null;
        return upgrade;
    }

    public static Upgrade CreateUpgrade(Train train, List<TrainCar> cars, int index)
    {
        Upgrade upgrade = new Upgrade();
        TrainCar car = cars[index];
        TurretStats newTurretStats = car.turret.turretStats.Copy();
        upgrade.upgrade = Upgrade.UpgradeType.ModifyStat;
        upgrade.train = train;
        upgrade.trainCar = car;

        if (car.turret.turretStats.ProjectileStats is BulletStats bulletStats)
        {
            BulletStats newStats = bulletStats.Copy();
            float percentIncrease;
            switch (RNG.rng.Next(0,3))
            {
                case 0:
                    percentIncrease = RNG.rng.Next(5, 25) / 100f;
                    float newDamage = bulletStats.BulletDamage * (1f + percentIncrease);
                    upgrade.name = $"Increase bullet damage for car {index} weapon";
                    upgrade.description = $"Increases the damage for car {index} weapon from {bulletStats.BulletDamage} -> {newDamage}";
                    newStats.SetBulletDamage(newDamage);
                    break;
                case 1:
                    percentIncrease = RNG.rng.Next(20, 50) / 100f;
                    float newSpeed = bulletStats.BulletSpeed * (1f + percentIncrease);
                    upgrade.name = $"Increase bullet speed for car {index} weapon";
                    upgrade.description = $"Increases the speed for car {index} weapon from {bulletStats.BulletSpeed} -> {newSpeed}";
                    newStats.SetBulletSpeed(newSpeed);
                    break;
                case 2:
                    percentIncrease = RNG.rng.Next(-20, -10) / 100f;
                    float newFireRate = car.turret.turretStats.FireRate * (1f + percentIncrease);
                    upgrade.name = $"Increase fire rate for car {index}  weapon";
                    upgrade.description = $"Increases the fire rate for car {index} weapon from {car.turret.turretStats.FireRate} -> {newFireRate}";
                    newTurretStats.FireRate = newFireRate;
                    break;
            }
        }
        else if (car.turret.turretStats.ProjectileStats is MissileStats missileStats)
        {
            MissileStats newStats = missileStats.Copy();
            float percentIncrease = RNG.rng.Next(5, 25) / 100f;
            switch (RNG.rng.Next(0, 3))
            {
                case 0:
                    percentIncrease = RNG.rng.Next(5, 25) / 100f;
                    float newDamage = missileStats.MissileDamage * (1f + percentIncrease);
                    upgrade.name = $"Increase missile damage for car {index} weapon";
                    upgrade.description = $"Increases the damage for car {index} weapon from {missileStats.MissileDamage} -> {newDamage}";
                    newStats.SetMissileDamage(newDamage);
                    break;
                case 1:
                    percentIncrease = RNG.rng.Next(20, 50) / 100f;
                    float newSpeed = missileStats.MissileSpeed * (1f + percentIncrease);
                    upgrade.name = $"Increase bullet speed for car {index} weapon";
                    upgrade.description = $"Increases the speed for car {index} weapon from {missileStats.MissileSpeed} -> {newSpeed}";
                    newStats.SetMissileSpeed(newSpeed);
                    break;
                case 2:
                    percentIncrease = RNG.rng.Next(-20, -10) / 100f;
                    float newFireRate = car.turret.turretStats.FireRate * (1f + percentIncrease);
                    upgrade.name = $"Increase fire rate for car {index}  weapon";
                    upgrade.description = $"Increases the fire rate for car {index} weapon from {car.turret.turretStats.FireRate} -> {newFireRate}";
                    newTurretStats.FireRate = newFireRate;
                    break;
            }
        }

        upgrade.turretStats = newTurretStats;

        return upgrade;
    }
}

public record Upgrade
{
    public enum UpgradeType
    {
        ModifyStat,
        NewTrainCar
    }

    public UpgradeType upgrade;
    public string name;
    public string description;
    public Train train;
    public TrainCar trainCar;
    public TurretStats turretStats;

    public void ApplyUpgrade()
    {
        Debug.Log($"Applying upgrade : {name}");
        if (upgrade == UpgradeType.ModifyStat )
        {
            trainCar.SetTrainAbility(turretStats);
        }
        else if (upgrade == UpgradeType.NewTrainCar )
        {
            train.AddTrainCar(turretStats);
        }
    }
}