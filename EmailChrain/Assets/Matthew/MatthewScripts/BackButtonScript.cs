using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButtonScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick() {
        transform.parent.gameObject.transform.parent.gameObject.transform.Find(PrevSceneScript.prevScenes.Pop()).gameObject.SetActive(true);
        transform.parent.gameObject.SetActive(false);
    }
}
