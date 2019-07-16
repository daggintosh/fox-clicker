using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Population : MonoBehaviour
{
    public int foxPop = 0;
    public Text popText;

    public Button spawnFoxButton;

    public Button plantSeedButton;
    int foxSeedPayout = 0;
    int foxSeeds = 0;
    public Text seedText;

    // Start is called before the first frame update
    void Start()
    {
        spawnFoxButton.onClick.AddListener(spawnButtonPress);
        plantSeedButton.onClick.AddListener(plantButtonPress);
        StartCoroutine(foxSeedInterval());
    }

    // Update is called once per frame
    void Update()
    {
        popText.text = "" + foxPop;
    }

    void spawnButtonPress()
    {
        foxPop++;
    }

    void plantButtonPress() {
        if(foxPop >= 25) {
            foxSeedPayout += 5;
            foxPop -= 25;
            foxSeeds++;
            seedText.text = "" + foxSeeds;
        }
    }

    IEnumerator foxSeedInterval(){
        while(true) {
            yield return new WaitForSeconds(5);
            foxPop += foxSeedPayout;
        }
    }
}
