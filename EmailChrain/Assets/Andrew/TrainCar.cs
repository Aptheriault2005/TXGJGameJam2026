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

    public void SetTrainAbility(TurretStats turretStats)
    {
        turret.SetTurretAbility(turretStats);
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

