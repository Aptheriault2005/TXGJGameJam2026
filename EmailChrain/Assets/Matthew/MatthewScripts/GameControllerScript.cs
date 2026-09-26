using UnityEngine;

public class GameControllerScript : MonoBehaviour
{

    public float levelTimer;
    public float maxLevelTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maxLevelTime = 10f;
        levelTimer = maxLevelTime;
    }

    // Update is called once per frame
    void Update()
    {
        levelTimer -= Time.deltaTime;
    }
}
