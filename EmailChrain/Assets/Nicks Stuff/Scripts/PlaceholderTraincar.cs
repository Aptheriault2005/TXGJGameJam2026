using UnityEngine;

public class PlaceholderTraincar : MonoBehaviour
{
    float deathmarch = 10;
    public bool dead = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Die()
    {
        deathmarch -= 1;
        if (deathmarch <= 0)
        {
            dead = true;
        }
        
    }

}
