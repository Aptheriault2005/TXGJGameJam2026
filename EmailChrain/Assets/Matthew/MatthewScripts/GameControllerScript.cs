using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class GameControllerScript : MonoBehaviour
{

    public float levelTimer;
    public float maxLevelTime;
    public int waveCounter;
    [SerializeField] int maxWave;
    [SerializeField] UpgradeSelection usScreen;
    [SerializeField] Train train;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        levelTimer = maxLevelTime;
        waveCounter = 0;
        StartCoroutine(EndWaveDelay(maxLevelTime + 1.5f));
    }

    // Update is called once per frame
    void Update()
    {
        levelTimer -= Time.deltaTime;

    }

    IEnumerator EndWaveDelay(float time) {
        yield return new WaitForSeconds(time);
        WaveEnd();
    }

    void WaveEnd() {
        if (waveCounter >= maxWave) {
            SceneManager.LoadScene("EndWinScreen");
        }
        else {
            foreach(TrainCar t in train.trainCars) {
                t.DeselectTrainCar();
            }
            usScreen.Displayed();
        }
    }

    public void UpgradeButtonClicked() {
        StartCoroutine(NextWaveDelay(1));
    }

    IEnumerator NextWaveDelay(float time) {
        yield return new WaitForSeconds(time);
        NextWave();
    }

    void NextWave() {
        waveCounter += 1;
        levelTimer = maxLevelTime;
        train.trainCars[0].SelectTrainCar();
        train.trainCars[0].DeselectTrainCar();
        train.trainCars[0].SelectTrainCar();
        StartCoroutine(EndWaveDelay(maxLevelTime + 1.5f));
    }
}
