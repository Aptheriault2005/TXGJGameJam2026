using System.Collections;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] float speed = 10f;
    [SerializeField] float health = 10f;
    [SerializeField] GameObject targetedCar;

    [SerializeField] GameObject EnemyP;
    [SerializeField] float FireRate = 2;

    private bool stopped = false;
    void Start()
    {
        GameObject[] actorsWithTag = GameObject.FindGameObjectsWithTag("Train Car");
        int target = Random.Range(0, actorsWithTag.Length);
        targetedCar = actorsWithTag[target];
        transform.LookAt(targetedCar.transform.position);
        StartCoroutine(Delay(2));
        
        InvokeRepeating("FireP", 1, FireRate);
    }

    // Update is called once per frame
    void Update()
    {
        if (stopped)
        {
            //transform.LookAt(targetedCar.transform.position);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, targetedCar.transform.position, (speed * Time.deltaTime));
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlaceholderTraincar>(out var component))
        {
            component.Die();   
            Destroy(this.gameObject);
        }
        if (other.TryGetComponent<Projectile>(out var comp2)) {
            Destroy(other.gameObject);
            Destroy(gameObject);
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

    void StopTime()
    {
        stopped = true;
        Debug.Log(stopped);
    }


}





