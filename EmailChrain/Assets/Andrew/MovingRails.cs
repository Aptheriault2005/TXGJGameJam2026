using System.Collections;
using UnityEngine;

public class MovingRails : MonoBehaviour
{
    public GameObject RailsPrefab;
    public float RailsLength = 60f;
    public float RailsSpeed = 10f;

    //private GameObject lastRail;
    public GameObject currentRail;
    public float currentTime = 0f;
    public float timeThreshold;

    void Start()
    {
        timeThreshold = RailsLength / RailsSpeed;
        currentRail = Instantiate(RailsPrefab);
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= timeThreshold) 
        {
            //if (lastRail != null)
            //{ 
            //    Destroy(lastRail);
            //}

            //lastRail = currentRail;
            Destroy(currentRail);
            currentRail = Instantiate(RailsPrefab);
            currentTime = 0;
        }
        //if (lastRail != null)
        //{
        //    lastRail.transform.position += (Vector3.back * RailsSpeed * Time.deltaTime);
        //}
        currentRail.transform.position += (Vector3.back * RailsSpeed * Time.deltaTime);
    }
}
