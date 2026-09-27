using System.Runtime;
using UnityEngine;

public class EnemyExploder : MonoBehaviour
{

    [SerializeField] float speed = 10f;
    //[SerializeField] float health = 10f;
    [SerializeField] GameObject targetedCar;
    [SerializeField] HealthComponent healthComponent;

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
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<TrainCar>(out var component))
        {
            component.GetComponent<HealthComponent>().Damage(1);
            healthComponent.Kill();
            //Destroy(gameObject);
        }
       
        if (other.TryGetComponent<Projectile>(out var comp2)) {
            healthComponent.Damage(comp2.GetDamage());
            //Destroy(other.gameObject);
            //Destroy(gameObject);
        }
    }

    public void OnDeath()
    {
        Destroy(gameObject);
    }
}
