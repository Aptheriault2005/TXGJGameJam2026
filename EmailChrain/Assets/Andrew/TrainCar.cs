using System;
using UnityEngine;

public class TrainCar : MonoBehaviour
{
    [SerializeField] private GameObject selectionIndicator;
    public Turret turret;

    private bool isDisabled = false;
    public bool isSelected = false;

    public void MousePositionUpdate(GameObject mousePosIndicator)
    {
        if (isSelected && !isDisabled)
        {
            turret.MoveTurret(mousePosIndicator.transform);
        }
    }

    public void SetTrainAbility(TurretStats turretStats)
    {
        turret.SetTurretAbility(turretStats);
    }

    public void UseTrainCarAbility()
    {
        if (!isSelected || isDisabled) return;

        turret.StartTurretAbility();
    }

    public void StopTrainCarAbility()
    {
        turret.StopTurretAbility();
    }

    public void ReviveTrainCar()
    {
        isDisabled = false;
        if (TryGetComponent<HealthComponent>(out var health))
        {
            health.FullHeal();
        }
    }

    public void DisableTrainCar() { isDisabled = true; }

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

    public void CheckDead() {
        print("checking dead");
        Train t = transform.parent.GetComponent<Train>();
        t.CheckAllDead();
    }
}

