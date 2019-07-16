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

    #region Begin Mining Foxes
    public Button startFoxMine;
    public Text mineText, minePriceText;
    double minePrice = 1000;
    int foxMinePayout, foxMines = 0;
    #endregion

    #region Spawn Quantum Foxes
    public Button spawnQuantumFox;
    public Text quantumText, quantumPriceText;
    double quantumPrice = 5000;
    int quantumPayout, quantumFoxes = 0;
    #endregion
    
    #region Find Planet
    public Button findFoxPlanet;
    public Text planetText, planetPriceText;
    double planetPrice = 15000;
    int planetPayout, foxPlanets = 0;
    #endregion

    #region End the Game
    public Button endGame;
    long humanPopulation = 7346235321;
    public Text humanPopText;
    #endregion

    void Start()
    {
        Time.timeScale = 1;

        spawnFoxButton.onClick.AddListener(spawnButtonPress);
        plantSeedButton.onClick.AddListener(plantButtonPress);
        sendFoxGun.onClick.AddListener(gunButtonPress);
        startFoxFactory.onClick.AddListener(factoryButtonPress);
        startFoxMine.onClick.AddListener(mineButtonPress);
        spawnQuantumFox.onClick.AddListener(quantumButtonPress);
        findFoxPlanet.onClick.AddListener(planetButtonPress);
        endGame.onClick.AddListener(killHumanity);

        StartCoroutine(foxSeedInterval());
        StartCoroutine(foxGunInterval());
        StartCoroutine(foxFactoryInterval());
        StartCoroutine(foxMineInterval());
        StartCoroutine(quantumFoxInterval());
        StartCoroutine(foxPlanetInterval());
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
    }

    void mineButtonPress()
    {
        switch (foxPop >= (int)minePrice)
        {
            case true:
                foxMinePayout += 90;
                foxPop -= (int)minePrice;
                foxMines++;
                mineText.text = "" + foxMines;
                minePrice *= 1.12;
                minePriceText.text = "" + (int)minePrice;
                break;
            default:
                break;
        }
    }

    void quantumButtonPress()
    {
        switch (foxPop >= (int)quantumPrice)
        {
            case true:
                quantumPayout += 237;
                foxPop -= (int)quantumPrice;
                quantumFoxes++;
                quantumText.text = "" + quantumFoxes;
                quantumPrice *= 1.20;
                quantumPriceText.text = "" + (int)quantumPrice;
                break;
            default:
                break;
        }
    }

    void planetButtonPress()
    {
        switch (foxPop >= (int)planetPrice)
        {
            case true:
                planetPayout += 7000;
                foxPop -= (int)planetPrice;
                foxPlanets++;
                planetText.text = "" + foxPlanets;
                planetPrice *= 1.99;
                planetPriceText.text = "" + (int)planetPrice;
                break;
            default:
                break;
        }
    }

    void killHumanity()
    {
        switch (foxPop >= 7346235321)
        {
            case true:
                foxPop -= 7346235321;
                StartCoroutine(destroyHumanity());
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

    IEnumerator foxMineInterval()
    {
        while(true) {
            yield return new WaitForSecondsRealtime(9);
            foxPop += foxMinePayout;
        }
    }

    IEnumerator quantumFoxInterval()
    {
        while(true) {
            yield return new WaitForSecondsRealtime(1);
            foxPop += quantumPayout;
        }
    }

    IEnumerator foxPlanetInterval()
    {
        while(true) {
            yield return new WaitForSecondsRealtime(3);
            foxPop += planetPayout;
        }
    }

    IEnumerator destroyHumanity()
    {
        while(humanPopulation >= 5) {
            yield return new WaitForSecondsRealtime(0.001F);
            humanPopulation -= 3349383;
            humanPopText.text = "" + humanPopulation;
        }
        humanPopText.text = "0";
        yield return new WaitForSecondsRealtime(1);
        Application.Quit();
    }
}
