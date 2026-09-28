using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class UpgradeSelection : MonoBehaviour
{
    [SerializeField] GameControllerScript gc;
    List<string> upgrades = new List<string>();
    [SerializeField] Button top;
    [SerializeField] Button mid;
    [SerializeField] Button bot;
    [SerializeField] RectTransform screen;
    [SerializeField] Train train;

    [SerializeField] Image txtBg;
    [SerializeField] TMPro.TextMeshProUGUI txt;
    List<string> flavorText = new List<string>();


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        flavorText.Add("Hello, valued IT intern! Unfortunately, due to a case of minor user error, our wise and spiritually powerful CEO was tricked into clicking on a very persuasive and well-written link, and now malware is launching an all-out attack on our database. Please send an email to the IT head to log the issue. Sincerely, Management");
        flavorText.Add("Hello, valued IT intern! The error has been logged. The malware is swift, and moves to corrupt our company database quickly should you fail to stop it! I've always believed in you, in your spirit and your soul, and I beg of thee, fight through this evil and save our company. Email Janice in HR. Sincerely, the mighty IT Head.");
        flavorText.Add("Hello, valued IT intern! I have reached out to external tech support and they need you to deliver an email to the CEO. This email contains a link to a YouTube video that will explain how to remove the malware. Our CEO is wise and spiritually powerful, he will be able to destroy the evil, but you have to deliver the email. First, however, you must email Gerald in PR to ensure that this YouTube video is fit for our CEO's consumption. Good luck, soldier. Sincerely, Janice from HR.");
        flavorText.Add("Hello, valued IT intern! I have watched this YouTube video in question, and while it contains all of the information needed by our wise and spiritually powerful CEO, it does also contain 33 minutes of pornographic material spliced into the middle. Please refer back to Janice in HR to log the transgression we are about to commit.");
        flavorText.Add("Hello, valued IT intern! We in the HR department are experiencing difficulties due to the malware. Please email our wise and spiritually powerful CEO's secretery, miss chase, to ensure our CEO will be capable of withstanding the pornographic material in question. Thank you! -Janice from HR");
        flavorText.Add("Hello, valued IT intern! Our wise and spiritually powerful CEO is morally disgusted by pornographic content, and will refuse to watch this video should you send it to him in its current state. Please contact the head of the IT department for further instructions. Thank you!");
        flavorText.Add("The malware is growing too powerful! The phishers and spamflies are cunning and diabolical, they plot our downfall, and you approach me to remove pornographic content from a You Tube video? How trite. I have sliced this obscenity asunder and now I send to you the moral version of the video. Be swift and report this to the secretery of our wise and spiritually powerful CEO so he may be mentally prepared for what is to come. Steel yourself, brave intern. -The fabled head of IT");
        flavorText.Add("Hello, valued IT intern! Our wise and spiritually powerful CEO would like confirmation from Janice in HR that the new version of the video does indeed contain no pornographic content! Thank yo- This is the malware speaking! We are launching an all out attack on your email account very soon! -The Malware");
        flavorText.Add("Hello, valued IT intern! This is Janice in HR! The malware is here! I am sending confirmation to the CEO, you must contact the secretery of our wise and spiritually powerful CEO, before it's too late!");
        flavorText.Add("We are launching an all out attack on your email. -The Malware");
        flavorText.Add("Hello, valued IT intern! It is I, the wise and spiritually powerful CEO of our company. I have obliterated the malware threat with my immense spiritual strength, dismantaling their society and causing them to crumble, all thanks to the YouTube video you sent! Thank you for your work, our company would be lost without you, and as such, we are giving you a $0.20/hr raise! Congratulations!");
        flavorText.Add("");
        flavorText.Add("");
        flavorText.Add("");
        flavorText.Add("");
        flavorText.Add("");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Displayed() {
        screen.gameObject.SetActive(true);

        txtBg.gameObject.SetActive(true);
        txt.gameObject.SetActive(true);
        Debug.Log($"{gc.waveCounter + 1} : {flavorText.Count}");
        txt.text = flavorText[gc.waveCounter + 1];
        List<Upgrade> upgrades = train.GetUpgrades();

        top.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = (upgrades[0].name + '\n' + upgrades[0].description);
        mid.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = (upgrades[1].name + '\n' + upgrades[1].description);
        bot.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = (upgrades[2].name + '\n' + upgrades[2].description);

        top.GetComponent<UpgradeButton>().upgrade = upgrades[0];
        mid.GetComponent<UpgradeButton>().upgrade = upgrades[1];
        bot.GetComponent<UpgradeButton>().upgrade = upgrades[2];
    }
}
