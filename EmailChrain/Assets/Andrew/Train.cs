using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Train : MonoBehaviour
{
    [SerializeField] private List<TrainCar> trainCars;
    private int currentIndex = 0;
    private PlayerActions playerActions;

    private void Awake()
    {
        playerActions = new();
        playerActions.PlayerControls.Enable();
        playerActions.PlayerControls.UseAbility.performed += OnAbilityUsed;
        playerActions.PlayerControls.MoveSelectionUp.performed += OnSelectionMoveUp;
        playerActions.PlayerControls.MoveSelectionDown.performed += OnSelectionMoveDown;
    }

    private void OnDestroy()
    {
        playerActions.PlayerControls.UseAbility.performed -= OnAbilityUsed;
        playerActions.PlayerControls.MoveSelectionUp.performed -= OnSelectionMoveUp;
        playerActions.PlayerControls.MoveSelectionDown.performed -= OnSelectionMoveDown;
        playerActions.Dispose();
    }

    private void Start()
    {
        foreach (TrainCar car in trainCars)
        {
            car.DeselectTrainCar();
        }

        currentIndex = 0;
        GetCurrentTrainCar().SelectTrainCar();
    }

    private void OnAbilityUsed(InputAction.CallbackContext context) 
    {
        GetCurrentTrainCar().UseTrainCarAbility();
    }

    private void OnSelectionMoveUp(InputAction.CallbackContext context) 
    {
        Debug.Log($"{currentIndex}");
        if (currentIndex > 0)
        {
            GetCurrentTrainCar().DeselectTrainCar();
            currentIndex--;
            GetCurrentTrainCar().SelectTrainCar();
        }
    }

    private void OnSelectionMoveDown(InputAction.CallbackContext context)
    {
        Debug.Log($"{currentIndex}");
        if (currentIndex < trainCars.Count - 1) 
        {
            GetCurrentTrainCar().DeselectTrainCar();
            currentIndex++;
            GetCurrentTrainCar().SelectTrainCar();
        }
    }

    public TrainCar GetCurrentTrainCar()
    {
        return trainCars[currentIndex];
    }

    public void AddTrainCar() { }

    public void RemoveTrainCar(int index) { }
}
