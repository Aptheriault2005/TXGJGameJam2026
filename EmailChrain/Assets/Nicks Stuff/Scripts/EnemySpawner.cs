using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float SpawnRate = 2f;
    [SerializeField] GameObject exploderPrefab;
    [SerializeField] GameObject shooterPrefab;

    double zmin = 0f;
    double zmax = 0f;
    float xLeft;
    float xRight;
    float sideSpawn;
    float distanceFromCam;

    double xdistance;

    private List<GameObject> spawnList = new List<GameObject>();
    private bool isPaused = false;


    bool leftSpawn = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0, SpawnRate);
    }

    public void StopSpawner()
    {
        foreach (GameObject spawn in spawnList) { Destroy(spawn); }

        isPaused = true;
    }

    public void ResumeSpawner()
    {
        isPaused = false;
    }

    void SpawnEnemy()
    {
        if (isPaused) return;


        xdistance = (Camera.main.transform.position.y / Math.Sin(Mathf.Deg2Rad * 37.875)) * Math.Sin(Mathf.Deg2Rad * 52.125);
        Debug.Log(xdistance);
        zmax = (Camera.main.transform.position.y / Math.Sin(Mathf.Deg2Rad * 43.409)) * Math.Sin(Mathf.Deg2Rad * 46.591);
        zmax += Camera.main.transform.position.z;
        zmin = -zmax;
        zmin += Camera.main.transform.position.z;

        float randz = UnityEngine.Random.Range((float)zmin, (float)zmax);
        if (UnityEngine.Random.Range(0, 2) == 0)
        {
            leftSpawn = true;
            xdistance = xdistance * -1;
            xdistance -= 1;
        }
        else
        {
            leftSpawn = false;
            xdistance += 1;

        }
        
        Debug.Log(new Vector3((float)xdistance, 0, randz));

        int randEnemy = UnityEngine.Random.Range(0, 3);
        if (randEnemy == 1)
        {
            GameObject exploder = Instantiate(exploderPrefab, new Vector3((float)xdistance, 0, randz), Quaternion.identity);
            spawnList.Add(exploder);
        }
        else if (randEnemy == 0)
        {
            GameObject shooter = Instantiate(shooterPrefab, new Vector3((float)xdistance, 0, randz), Quaternion.identity);
            spawnList.Add(shooter);
        }

    }

}
