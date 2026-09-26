using UnityEngine;
using UnityEngine.UI;

public class ProgressBarScript : MonoBehaviour
{

    [SerializeField] GameControllerScript controller;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Slider>().value = ((controller.maxLevelTime - controller.levelTimer) / controller.maxLevelTime);
    }
}
