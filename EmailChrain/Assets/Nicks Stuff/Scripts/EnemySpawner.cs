using System;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    private bool isPaused = false;

    [SerializeField] int groupPercent;
    bool leftSpawn = false;


    private float realSpawnRate;
    private int Wave = 1;
    [SerializeField] GameControllerScript gcs;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        realSpawnRate = SpawnRate - Wave / 10;
        groupPercent = Wave * 5;
        InvokeRepeating("SpawnEnemy", 0, realSpawnRate);
    }

    public void StopSpawner()
    {
        Debug.Log("PAUSED");
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("enemy"))
        { 
            if (enemy.TryGetComponent<HealthComponent>(out var health))
            {
                health.Kill();
            }
            else
            {
                Destroy(enemy);
            }
        }

        isPaused = true;
    }

    public void ResumeSpawner()
    {
        Debug.Log("RESUME");
        isPaused = false;

        Wave = gcs.waveCounter;
        realSpawnRate -= ((float)Wave / (float)10);
        groupPercent = Wave * 5;

        Debug.Log(Wave);
        Debug.Log(realSpawnRate);
        CancelInvoke("SpawnEnemy");

        InvokeRepeating("SpawnEnemy", 0, realSpawnRate);

    }

    void SpawnEnemy()
    {
        if (isPaused) return;

        

        bool groupSpawn = (UnityEngine.Random.Range(1, 101) <= groupPercent);

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

        int randEnemy = UnityEngine.Random.Range(0, 2);
        if (randEnemy == 1)
        {
            GameObject exploder = Instantiate(exploderPrefab, new Vector3((float)xdistance, 0, randz), Quaternion.identity);


            if (groupSpawn)
            {
                if (xdistance < 0)
                {
                    if (UnityEngine.Random.Range(0, 2) == 0)
                    {
                        Instantiate(exploderPrefab, new Vector3((float)xdistance - 3, 0, randz + 3), Quaternion.identity);
                        Instantiate(exploderPrefab, new Vector3((float)xdistance - 6, 0, randz - 3), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(exploderPrefab, new Vector3((float)xdistance - 6, 0, randz + 3), Quaternion.identity);
                        Instantiate(exploderPrefab, new Vector3((float)xdistance - 3, 0, randz - 3), Quaternion.identity);
                    }

                }
                else
                {
                    if (UnityEngine.Random.Range(0, 2) == 0)
                    {
                        Instantiate(exploderPrefab, new Vector3((float)xdistance + 3, 0, randz + 3), Quaternion.identity);
                        Instantiate(exploderPrefab, new Vector3((float)xdistance + 6, 0, randz - 3), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(exploderPrefab, new Vector3((float)xdistance + 6, 0, randz + 3), Quaternion.identity);
                        Instantiate(exploderPrefab, new Vector3((float)xdistance + 3, 0, randz - 3), Quaternion.identity);
                    }
                } 
            }
        }
        else if (randEnemy == 0)
        {
            GameObject shooter = Instantiate(shooterPrefab, new Vector3((float)xdistance, 0, randz), Quaternion.identity);

            if (groupSpawn)
            {
                if (xdistance < 0)
                {
                    if (UnityEngine.Random.Range(0, 2) == 0)
                    {
                        Instantiate(shooterPrefab, new Vector3((float)xdistance - 3, 0, randz + 3), Quaternion.identity);
                        Instantiate(shooterPrefab, new Vector3((float)xdistance - 6, 0, randz - 3), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(shooterPrefab, new Vector3((float)xdistance - 6, 0, randz + 3), Quaternion.identity);
                        Instantiate(shooterPrefab, new Vector3((float)xdistance - 3, 0, randz - 3), Quaternion.identity);
                    }

                }
                else
                {
                    if (UnityEngine.Random.Range(0, 2) == 0)
                    {
                        Instantiate(shooterPrefab, new Vector3((float)xdistance + 3, 0, randz + 3), Quaternion.identity);
                        Instantiate(shooterPrefab, new Vector3((float)xdistance + 6, 0, randz - 3), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(shooterPrefab, new Vector3((float)xdistance + 6, 0, randz + 3), Quaternion.identity);
                        Instantiate(shooterPrefab, new Vector3((float)xdistance + 3, 0, randz - 3), Quaternion.identity);
                    }
                }
            }

        }
    }
}
