using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class EnemyShooter : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] float speed = 10f;
    //[SerializeField] float health = 10f;
    [SerializeField] GameObject targetedCar;
    [SerializeField] HealthComponent healthComponent;

    [SerializeField] GameObject EnemyP;
    [SerializeField] float FireRate = 2;

    private bool stopped = false;

    private bool firstTime = true;
    private bool goingLeft = false;
    [SerializeField] float sSpeed = 1f;
    [SerializeField] float rSpeed = 4f;
    private bool hovered = false;
    List<GameObject> validActors = new List<GameObject>();


    float rxAmount = 0;
    float rZAmount = 0;
    void Start()
    {
        GameObject[] actorsWithTag = GameObject.FindGameObjectsWithTag("Train Car");
        int target = Random.Range(0, actorsWithTag.Length);
        targetedCar = actorsWithTag[target];
        transform.LookAt(targetedCar.transform.position);
        StartCoroutine(Delay(2));

        

        InvokeRepeating("FireP", 1, FireRate);

        StartCoroutine(Delay(2));
    }

    // Update is called once per frame
    void Update()
    {
        if (stopped)
        {
            transform.LookAt(targetedCar.transform.position);

            //Switch code

            transform.LookAt(targetedCar.transform.position);
            //      if (targetedCar.GetComponent<HealthComponent>().currentHealth > 0 )
            if (!targetedCar.GetComponent<TrainCar>().IsDestroyed())
            {
                List<GameObject> validActors = new List<GameObject>();
                GameObject[] actorsWithTag = GameObject.FindGameObjectsWithTag("Train Car");
                foreach (GameObject actor in actorsWithTag)
                {
                    if (!actor.GetComponent<TrainCar>().IsDestroyed()) 
                    {
                        validActors.Add(actor);
                    }
                }
                if (validActors.Count != 0)
                {
                    int target = Random.Range(0, validActors.Count);
                    targetedCar = validActors[target];
                    Debug.Log("target swap");
                }
                
            }
            //Switch code

            // Bad hover code

            //if (hovered == false)
            //{

            //    int xset = Random.Range(-1, 2);
            //    int zset = Random.Range(-1, 2);
            //    if (xset == 0 && zset == 0)
            //    {
            //        xset = 1;
            //    }
            //    rxAmount = (float)xset;
            //    rZAmount = (float)zset;

            //    Transform hoverSpot = transform;
            //    hoverSpot.position += new Vector3(rxAmount, 0f, rZAmount);
            //    //  transform.RotateAround(hoverSpot.position, Vector3.left, rSpeed * Time.deltaTime);
            //    hovered = true;
            //}
            //else
            //{
            //    Transform hoverSpot = transform;
            //    hoverSpot.position += new Vector3(rxAmount, 0f, rZAmount);
            //    // transform.RotateAround(hoverSpot.position, Vector3.left, rSpeed * Time.deltaTime);
            //}


            // Bad hover code


            // bad strafe 

            //if (goingLeft)
            //{
            //    Vector3 offsetDir = Quaternion.Euler(0, 90, 0) * transform.forward;
            //   // transform.position = offsetDir * sSpeed * Time.deltaTime;
            //}
            //else
            //{
            //    Vector3 offsetDir = Quaternion.Euler(0, -90, 0) * transform.forward;
            //    // transform.position = offsetDir * sSpeed * Time.deltaTime;
            //}
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, targetedCar.transform.position, (speed * Time.deltaTime));
            //Switch code

            transform.LookAt(targetedCar.transform.position);
            //      if (targetedCar.GetComponent<HealthComponent>().currentHealth > 0 )
            if (targetedCar.GetComponent<TrainCar>().IsDestroyed())
            {
                List<GameObject> validActors = new List<GameObject>();
                GameObject[] actorsWithTag = GameObject.FindGameObjectsWithTag("Train Car");
                foreach (GameObject actor in actorsWithTag)
                {

                    if (!actor.GetComponent<TrainCar>().IsDestroyed())
                    {
                        validActors.Add(actor);
                    }
                }
                if (validActors.Count != 0)
                {
                    int target = Random.Range(0, validActors.Count);
                    targetedCar = validActors[target];
                }

            }
            //Switch code

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.TryGetComponent<PlaceholderTraincar>(out var component))
        //{
        //    component.Die();
        //    Destroy(this.gameObject);
        //}
        if (other.TryGetComponent<TrainCar>(out var component))
        {
            component.GetComponent<HealthComponent>().Damage(1);
            healthComponent.Kill();
        }
        if (other.TryGetComponent<Projectile>(out var comp2)) {
            healthComponent.Damage(comp2.GetDamage());
            //Destroy(other.gameObject);
            //Destroy(gameObject);
        }
    }

    void FireP()
    {
        Instantiate(EnemyP, transform.position, Quaternion.LookRotation(targetedCar.transform.position - transform.position)  );
    }

    IEnumerator Delay(float time)
    {
        yield return new WaitForSeconds(time);
        StopTime();
    }

    IEnumerator StrifeTime(float time)
    {
        if (firstTime)
        {
            if (Random.Range(0, 2) == 0)
            {
                goingLeft = false;
            }
            else
            {
                goingLeft = true;
            }
            firstTime = false;

            yield return new WaitForSeconds(time/2);
            if (goingLeft)
            {
                goingLeft = false;
            }
            else
            {
                goingLeft = true;
            }
        }
        else
        {
            yield return new WaitForSeconds(time);
            if (goingLeft)
            {
                goingLeft = false;
            }
            else
            {
                goingLeft = true;
            }
        }
        
        StartCoroutine(StrifeTime(time));
    }

    void StopTime()
    {
        stopped = true;
        Debug.Log(stopped);
    }

    public void OnDeath()
    {
        Destroy(gameObject);
    }
}





