using UnityEngine;

public class GameControllerScript : MonoBehaviour
{

    public float levelTimer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        levelTimer = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        levelTimer -= Time.deltaTime;
    }
}
