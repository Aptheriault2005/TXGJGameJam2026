using UnityEngine;
using UnityEngine.SceneManagement;

public class MenusScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log(SceneManager.GetActiveScene().name);
        if (SceneManager.GetActiveScene().name == "MainMenu") {
            transform.Find("Background").gameObject.SetActive(true);
            transform.Find("Background").gameObject.transform.Find("MainMenus").gameObject.SetActive(true);
        }
        else if (SceneManager.GetActiveScene().name == "EndLoseScreen") {
            transform.Find("Background").gameObject.SetActive(true);
            transform.Find("Background").gameObject.transform.Find("EndLose").gameObject.SetActive(true);
        }
        else if (SceneManager.GetActiveScene().name == "EndWinScreen") {
            transform.Find("Background").gameObject.SetActive(true);
            transform.Find("Background").gameObject.transform.Find("EndWin").gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
