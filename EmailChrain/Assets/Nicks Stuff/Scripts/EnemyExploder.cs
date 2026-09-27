using System.Collections.Generic;
using System.Runtime;
using UnityEngine;

public class EnemyExploder : MonoBehaviour
{

    [SerializeField] float speed = 10f;
    [SerializeField] float health = 10f;
    [SerializeField] GameObject targetedCar;

    private void Awake()
    {

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // code ghost ->    

        GameObject[] actorsWithTag = GameObject.FindGameObjectsWithTag("Train Car");
        int target = Random.Range(0, actorsWithTag.Length);
        targetedCar = actorsWithTag[target];
        transform.LookAt(targetedCar.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        // if (targetedCar.isDead = true)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetedCar.transform.position, (speed * Time.deltaTime));
        }

        //Switch code

        transform.LookAt(targetedCar.transform.position);
        //      if (targetedCar.GetComponent<HealthComponent>().currentHealth > 0 )
        if (targetedCar.GetComponent<PlaceholderTraincar>().dead == true)
        {
            List<GameObject> validActors = new List<GameObject>();
            GameObject[] actorsWithTag = GameObject.FindGameObjectsWithTag("Train Car");
            foreach (GameObject actor in actorsWithTag)
            {

                if (actor.GetComponent<PlaceholderTraincar>().dead == false)
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlaceholderTraincar>(out var component))
        {
            component.Die();
            Destroy(gameObject);
        }
       
        if (other.gameObject.tag == "Laser")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
