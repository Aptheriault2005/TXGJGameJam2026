using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.UIElements;

public class EvilProjectile : MonoBehaviour
{
    [SerializeField] float laserSpeed = 1.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * laserSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlaceholderTraincar>(out var component))
        {
            component.Die();   // damage the train
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Laser")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
