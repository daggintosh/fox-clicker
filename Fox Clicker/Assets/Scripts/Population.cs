using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Population : MonoBehaviour
{
    #region Population Initiation
    public long foxPop = 0;
    public Text popText;
    public Button spawnFoxButton;
    #endregion

    #region Plant Fox Seed
    public Button plantSeedButton;
    public Text seedText, seedPriceText;
    double seedPrice = 25;
    int foxSeedPayout, foxSeeds = 0;
    #endregion

    #region Give Fox Gun
    public Button sendFoxGun;
    public Text gunText, gunPriceText;
    double gunPrice = 200;
    int foxGunPayout, foxGuns = 0;
    #endregion

    #region Start Cloning Foxes
    public Button startFoxFactory;
    public Text factoryText, factoryPriceText;
    double factoryPrice = 500;
    int foxFactoryPayout, foxFactories = 0;
    #endregion

    void Start()
    {
        Time.timeScale = 1;
        spawnFoxButton.onClick.AddListener(spawnButtonPress);
        plantSeedButton.onClick.AddListener(plantButtonPress);
        sendFoxGun.onClick.AddListener(gunButtonPress);
        startFoxFactory.onClick.AddListener(factoryButtonPress);
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
        switch (foxPop >= (int)gunPrice)
        {
            case true:
                foxGunPayout += 20;
                foxPop -= (int)gunPrice;
                foxGuns++;
                gunText.text = "" + foxGuns;
                gunPrice *= 1.03;
                gunPriceText.text = "" + (int)gunPrice;
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

    void factoryButtonPress()
    {
        switch (foxPop >= (int)factoryPrice)
        {
            case true:
                foxFactoryPayout += 43;
                foxPop -= (int)factoryPrice;
                foxFactories++;
                factoryText.text = "" + foxFactories;
                factoryPrice *= 1.09;
                factoryPriceText.text = "" + (int)factoryPrice;
                break;
            default:
                break;
        }
        switch(foxFactories == 1) 
        {
            case true:
                StartCoroutine(foxFactoryInterval());
                break;
            default:
                break;
        }
    }

    IEnumerator foxSeedInterval()
    {
        while(true) {
            yield return new WaitForSecondsRealtime(5);
            foxPop += foxSeedPayout;
        }
    }

    IEnumerator foxGunInterval()
    {
        while(true) {
            yield return new WaitForSecondsRealtime(4);
            foxPop += foxGunPayout;
        }
    }
    
    IEnumerator foxFactoryInterval()
    {
        while(true) {
            yield return new WaitForSecondsRealtime(2);
            foxPop += foxFactoryPayout;
        }
    }
}
