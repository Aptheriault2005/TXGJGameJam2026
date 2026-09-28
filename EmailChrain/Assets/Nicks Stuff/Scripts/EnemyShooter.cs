//using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
//using UnityEditor.UI;
using UnityEngine;
//using UnityEngine.UI;
//using static UnityEngine.GraphicsBuffer;

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

    float strafeDirection = 0;
    float timer;
    [SerializeField] float strafeTime;
    float rxAmount = 0;
    float rZAmount = 0;
    void Start()
    {
        AudioManager.PlayBugSFX();
        GameObject[] actorsWithTag = GameObject.FindGameObjectsWithTag("Train Car");
        int target = Random.Range(0, actorsWithTag.Length);
        targetedCar = actorsWithTag[target];
        transform.LookAt(targetedCar.transform.position);
        StartCoroutine(Delay(2));

        

        InvokeRepeating("FireP", 1, FireRate);


        //Strafe
        if (Random.Range(0, 2) == 0)
        {
            strafeDirection = -1;
        }
        else
        {
            strafeDirection = 1;
        }
        //
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

            /*// Bad hover code

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


            // Bad hover code*/


            // dumb strafe 

            timer += Time.deltaTime;
            if (firstTime) 
            {
                if (timer >= strafeTime)
                {
                    
                    strafeDirection *= -1;
                    timer = 0;
                    firstTime = false;
                }
            }
            else
            {
                if (timer >= strafeTime)
                {
                    strafeDirection *= -1;
                    timer = 0;
                }
            }
            Vector3 strafeDistance = transform.right * strafeDirection * sSpeed * Time.deltaTime;
            transform.position += strafeDistance;

            //


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
        AudioManager.PlayEnemyShootSFX();
        Instantiate(EnemyP, transform.position, Quaternion.LookRotation(targetedCar.transform.position - transform.position)  );
    }

    IEnumerator Delay(float time)
    {
        yield return new WaitForSeconds(time);
        StopTime();
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

    public void OnHurt()
    {
        AudioManager.PlayEnemyHurtSFX();
    }
}





