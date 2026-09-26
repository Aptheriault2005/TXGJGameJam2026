using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class UpgradeSelection : MonoBehaviour
{

    List<string> upgrades = new List<string>();
    [SerializeField] Button top;
    [SerializeField] Button mid;
    [SerializeField] Button bot;
    [SerializeField] RectTransform screen;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Displayed() {
        screen.gameObject.SetActive(true);

        for (int i= 0; i < 10; i ++) {
            upgrades.Add(""+ i);
        }
        int randIdx = Random.Range(0, 10);
        top.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = upgrades[randIdx];
        upgrades.RemoveAt(randIdx);
        randIdx = Random.Range(0, 9);
        mid.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = upgrades[randIdx];
        upgrades.RemoveAt(randIdx);
        randIdx = Random.Range(0, 8);
        bot.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = upgrades[randIdx];
        upgrades.RemoveAt(randIdx);
    }
}
