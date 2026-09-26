using System;
using UnityEngine;

public class TrainCar : MonoBehaviour
{
    [SerializeField] private GameObject selectionIndicator;
    [SerializeField] private GameObject turretPivot;
    [SerializeField] private GameObject bulletSpawnPoint;
    [SerializeField] private GameObject bulletPrefab;

    private bool isSelected = false;

    public void MousePositionUpdate(GameObject mousePosIndicator)
    {
        if (isSelected)
        {
            turretPivot.transform.LookAt(mousePosIndicator.transform);
            Debug.Log($"{turretPivot.transform.rotation.eulerAngles}");
            turretPivot.transform.rotation = Quaternion.Euler(0, turretPivot.transform.rotation.eulerAngles.y, 0);
        }
    }

    public void UseTrainCarAbility()
    {
        Debug.Log($"{gameObject.name} train car abilty used");
        Instantiate(bulletPrefab, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);
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
}
