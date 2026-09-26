using UnityEngine;
using UnityEngine.UI;

public class ProgressBarScript : MonoBehaviour
{

    Slider pBar;
    [SerializeField] GameControllerScript controller;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pBar = (Slider) FindFirstObjectByType(typeof(Slider));
    }

    // Update is called once per frame
    void Update()
    {
        pBar.value = ((controller.maxLevelTime - controller.levelTimer) / controller.maxLevelTime);
    }
}
