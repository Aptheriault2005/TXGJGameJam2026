using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class GameControllerScript : MonoBehaviour
{

    public float levelTimer;
    public float maxLevelTime;
    int waveCounter;
    [SerializeField] int maxWave;
    [SerializeField] UpgradeSelection usScreen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        levelTimer = maxLevelTime;
        waveCounter = 0;
        StartCoroutine(Delay(maxLevelTime + 1.5f));
    }

    // Update is called once per frame
    void Update()
    {
        levelTimer -= Time.deltaTime;

    }

    IEnumerator Delay(float time) {
        yield return new WaitForSeconds(time);
        WaveEnd();
    }

    void WaveEnd() {
        if (waveCounter >= maxWave) {
            SceneManager.LoadScene("EndWinScreen");
        }
        else {
            usScreen.Displayed();
        }
    }
}
