using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{

    [SerializeField] GameControllerScript gcs;
    public Upgrade upgrade;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick() {
        upgrade.ApplyUpgrade();
        gcs.UpgradeButtonClicked();
        transform.parent.gameObject.SetActive(false);
    }
}
