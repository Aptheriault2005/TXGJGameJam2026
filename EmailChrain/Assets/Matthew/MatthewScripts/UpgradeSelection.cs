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
    [SerializeField] Train train;


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

        List<Upgrade> upgrades = train.GetUpgrades();

        top.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = (upgrades[0].name + '\n' + upgrades[0].description);
        mid.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = (upgrades[1].name + '\n' + upgrades[1].description);
        bot.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = (upgrades[2].name + '\n' + upgrades[2].description);

        top.GetComponent<UpgradeButton>().upgrade = upgrades[0];
        mid.GetComponent<UpgradeButton>().upgrade = upgrades[1];
        bot.GetComponent<UpgradeButton>().upgrade = upgrades[2];
    }
}
