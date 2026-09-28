using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Train : MonoBehaviour
{
    public const float TrainLength = 2f;

    [SerializeField] private LayerMask mouseTargetLayerMask;
    [SerializeField] private GameObject mousePositionIndicator;
    [SerializeField] private List<TurretStats> turretStatsList = new();
    [SerializeField] public List<TrainCar> trainCars = new ();
    [SerializeField] private GameObject trainCarPrefab;
    [SerializeField] private GameObject trainCarFrontPrefab;
    [SerializeField] private GameObject nextTrainCarPosition;
    [SerializeField] GameControllerScript gcs;

    public int currentIndex = 0;
    private PlayerActions playerActions;
    private System.Random rng;
    private List<GameObject> trainSections = new();

    private void Awake()
    {
        rng = new System.Random();
        playerActions = new();
        playerActions.PlayerControls.Enable();
        playerActions.PlayerControls.UseAbility.performed += OnAbilityUsed;
        playerActions.PlayerControls.UseAbility.canceled += OnAbilityCanceled;
        playerActions.PlayerControls.MoveSelectionUp.performed += OnSelectionMoveUp;
        playerActions.PlayerControls.MoveSelectionDown.performed += OnSelectionMoveDown;
        playerActions.PlayerControls.NewTrainCar.performed += OnNewTrainCar;
        //playerActions.PlayerControls.DestroyTrainCar.performed += OnDestroyTrainCar;
        playerActions.PlayerControls.SelfDamage.performed += OnSelfDamage;
        playerActions.PlayerControls.Pause.performed += OnPause;
    }

    private void OnDestroy()
    {
        playerActions.PlayerControls.UseAbility.performed -= OnAbilityUsed;
        playerActions.PlayerControls.UseAbility.canceled -= OnAbilityCanceled;
        playerActions.PlayerControls.MoveSelectionUp.performed -= OnSelectionMoveUp;
        playerActions.PlayerControls.MoveSelectionDown.performed -= OnSelectionMoveDown;
        playerActions.PlayerControls.NewTrainCar.performed -= OnNewTrainCar;
        //playerActions.PlayerControls.DestroyTrainCar.performed -= OnDestroyTrainCar;
        playerActions.PlayerControls.SelfDamage.performed -= OnSelfDamage;
        playerActions.PlayerControls.Pause.performed -= OnPause;
        playerActions.PlayerControls.Disable();
        playerActions.Dispose();
    }

    private void Start()
    {
        AddFrontTrainCar();
        AddTrainCar(turretStatsList[rng.Next(0, turretStatsList.Count)]);

        currentIndex = 0;
        GetCurrentTrainCar().SelectTrainCar();
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (Physics.Raycast(ray, out RaycastHit hitInfo, 1000, mouseTargetLayerMask)) 
        {
            mousePositionIndicator.transform.position = new Vector3(hitInfo.point.x, 0, hitInfo.point.z);
            GetCurrentTrainCar().MousePositionUpdate(mousePositionIndicator);
        }
    }

    private void OnNewTrainCar(InputAction.CallbackContext context)
    {
        AddTrainCar(turretStatsList[rng.Next(0, turretStatsList.Count)]);
    }

    private void OnDestroyTrainCar(InputAction.CallbackContext context)
    {
        RemoveLastTrainCar();
    }

    private void OnAbilityUsed(InputAction.CallbackContext context) 
    {
        GetCurrentTrainCar().UseTrainCarAbility();
    }

    private void OnAbilityCanceled(InputAction.CallbackContext context)
    {
        GetCurrentTrainCar().StopTrainCarAbility();
    }

    private void OnSelectionMoveUp(InputAction.CallbackContext context) 
    {
        Debug.Log($"{currentIndex}");
        if (GetCurrentTrainCar().isSelected && currentIndex > 0)
        {
            GetCurrentTrainCar().DeselectTrainCar();
            currentIndex--;
            GetCurrentTrainCar().SelectTrainCar();
        }
    }

    private void OnSelectionMoveDown(InputAction.CallbackContext context)
    {
        Debug.Log($"{currentIndex}");
        if (GetCurrentTrainCar().isSelected && currentIndex < trainCars.Count - 1) 
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

    public void AddFrontTrainCar()
    {
        GameObject newCar = Instantiate(trainCarFrontPrefab, transform);
        newCar.transform.position = nextTrainCarPosition.transform.position;
        nextTrainCarPosition.transform.position += new Vector3(0, 0, -2.1f);
        trainSections.Add(newCar);
        UpdateCameraPosition();
    }

    public void AddTrainCar(TurretStats turretStats) 
    {
        GameObject newCar = Instantiate(trainCarPrefab, transform);
        newCar.transform.position = nextTrainCarPosition.transform.position;
        TrainCar trainCar = newCar.GetComponent<TrainCar>();
        trainCar.DeselectTrainCar();
        trainCar.SetTrainAbility(turretStats);
        trainCars.Add(trainCar);
        trainSections.Add(newCar);
        nextTrainCarPosition.transform.position += new Vector3(0, 0, -2.1f);
        UpdateCameraPosition();

        //GetUpgrades();
    }

    public void RemoveLastTrainCar()
    {
        if (trainCars.Count > 1) {
            TrainCar carToDestroy = trainCars[trainCars.Count - 1];
            trainCars.Remove(carToDestroy);
            carToDestroy.DeselectTrainCar();
            Destroy(carToDestroy.gameObject);

            nextTrainCarPosition.transform.position += new Vector3(0, 0, 2.1f);

            int newIndex = Mathf.Clamp(currentIndex, 0, trainCars.Count - 1);
            if (currentIndex != newIndex)
            {
                currentIndex = newIndex;
                GetCurrentTrainCar().SelectTrainCar();
            }

            UpdateCameraPosition();
        }
    }

    public List<Upgrade> GetUpgrades()
    {
        List<Upgrade> upgrades = new List<Upgrade>();

        Debug.Log("---");

        Upgrade upgrade = UpgradeSystem.CreateNewTrainCarUpgrade(this, turretStatsList, RNG.rng.Next(0, turretStatsList.Count));
        upgrades.Add(upgrade);
        Debug.Log($"{upgrade.name}, {upgrade.description}");

        for (int i = 0; i < 2; i++)
        {   
            upgrade = UpgradeSystem.CreateUpgrade(this, trainCars, RNG.rng.Next(0, trainCars.Count));
            if (upgrade == null)
            {
                upgrade = UpgradeSystem.CreateNewTrainCarUpgrade(this, turretStatsList, RNG.rng.Next(0, turretStatsList.Count));
                upgrades.Add(upgrade);
            }
            else
            {
                upgrades.Add(upgrade);
            }
            Debug.Log($"{upgrade.name}, {upgrade.description}");
        }

        //upgrades[RNG.rng.Next(0, 3)].ApplyUpgrade();

        Debug.Log("---");

        return upgrades;
    }

    private void UpdateCameraPosition()
    {
        if (trainSections.Count > 0)
        {
            Vector3 MidCarPos = trainSections[trainSections.Count / 2].transform.position;
            Camera.main.transform.position = new Vector3 (MidCarPos.x, 5 + (trainSections.Count * TrainLength), MidCarPos.z);
        }
    }

    private void OnSelfDamage(InputAction.CallbackContext context) {
        GetCurrentTrainCar().GetComponent<HealthComponent>().Damage(1);
    }

    public void CheckAllDead() {
        foreach(TrainCar t in trainCars) {
            if (t.GetComponent<HealthComponent>().currentHealth > 0) {
                print("alive");
                return;
            }
        }
        playerActions.PlayerControls.Disable();
        SceneManager.LoadScene("EndLoseScreen");
    }

    private void OnPause(InputAction.CallbackContext context) {
        Application.Quit();
    }
}
