using UnityEngine;

public class ProjectilesSingleton : MonoBehaviour
{
    public static ProjectilesSingleton instance;

    private void Awake()
    {
        if (instance != null) 
        {
            Destroy(gameObject);
        }

        instance = this;

        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
    }

    public GameObject Spawn(GameObject prefab)
    {
        return Instantiate(prefab, transform);
    }
}
