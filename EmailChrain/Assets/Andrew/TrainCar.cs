using System;
using UnityEngine;

public class TrainCar : MonoBehaviour
{
    [SerializeField] private GameObject selectionIndicator;

    public void UseTrainCarAbility()
    {
        Debug.Log($"{gameObject.name} train car abilty used");
    }

    public void SelectTrainCar() 
    {
        selectionIndicator.SetActive(true);
    }

    public void DeselectTrainCar() 
    {
        selectionIndicator.SetActive(false);
    }
}
