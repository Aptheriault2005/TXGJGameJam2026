using UnityEngine;

public class TestingScript : MonoBehaviour
{

    bool up;
    bool down;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        up = true;
        down = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (up) {
            transform.position += (new Vector3(0, 10, 0) * Time.deltaTime);
            if (transform.position.y >= 20) {
                down = true;
                up = false;
            }
        }
        if (down) {
            transform.position -= (new Vector3(0, 10, 0) * Time.deltaTime);
            if (transform.position.y <= 0) {
                up = true;
                down = false;
            }
        }

    }
}
