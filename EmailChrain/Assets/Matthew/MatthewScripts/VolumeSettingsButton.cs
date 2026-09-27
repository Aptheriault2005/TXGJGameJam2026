using UnityEngine;
using UnityEngine.SceneManagement;

public class VolumeSettingsButton : MonoBehaviour
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
        PrevSceneScript.prevScenes.Push(transform.parent.gameObject.name);
        transform.parent.gameObject.transform.parent.gameObject.transform.Find("VolumeMenu").gameObject.SetActive(true);
        transform.parent.gameObject.SetActive(false);
    }
}
