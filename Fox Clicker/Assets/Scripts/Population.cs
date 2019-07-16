using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Population : MonoBehaviour
{
    #region Population Initiation
    public int foxPop = 0;
    public Text popText;
    public Button spawnFoxButton;
    #endregion

    #region Plant Fox Seed
    public Button plantSeedButton;
    int foxSeedPayout = 0;
    int foxSeeds = 0;
    double seedPrice = 25;
    public Text seedText;
    public Text seedPriceText;
    #endregion

    #region Give Fox Gun
    public Button sendFoxGun;
    public Text gunText;
    int foxGunPayout = 0;
    int foxGuns = 0;
    #endregion

    void Start()
    {
        spawnFoxButton.onClick.AddListener(spawnButtonPress);
        plantSeedButton.onClick.AddListener(plantButtonPress);
        sendFoxGun.onClick.AddListener(gunButtonPress);
    }

    void Update()
    {
        popText.text = "" + foxPop;
    }

    void spawnButtonPress()
    {
        foxPop++;
    }

    void plantButtonPress()
     {
        switch (foxPop >= (int)seedPrice) 
        {
            case true:
                foxSeedPayout += 5;
                foxPop -= (int)seedPrice;
                foxSeeds++;
                seedText.text = "" + foxSeeds;
                seedPrice *= 1.05;
                seedPriceText.text = "" + (int)seedPrice;
                break;
            default:
                break;
        }
        switch (foxSeeds == 1) 
        {
            case true:
                StartCoroutine(foxSeedInterval());
                break;
            default:
                break;
        }
    }

    void gunButtonPress() 
    {
        switch (foxPop >= 200)
        {
            case true:
                foxGunPayout += 20;
                foxPop -= 200;
                foxGuns++;
                gunText.text = "" + foxGuns;
                break;
            default:
                break;
        }
        switch(foxGuns == 1) 
        {
            case true:
                StartCoroutine(foxGunInterval());
                break;
            default:
                break;
        }
    }

    IEnumerator foxSeedInterval()
    {
        while(true) {
            yield return new WaitForSeconds(5);
            foxPop += foxSeedPayout;
        }
    }

    IEnumerator foxGunInterval()
    {
        while(true) {
            yield return new WaitForSeconds(4);
            foxPop += foxGunPayout;
        }
    }
}
