using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Population : MonoBehaviour
{
    public int foxPop = 0;
    public Text text;
    public Button spawnFoxButton;

    // Start is called before the first frame update
    void Start()
    {
        spawnFoxButton.onClick.AddListener(spawnButtonPress);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnButtonPress()
    {
        foxPop++;
        text.text = "" + foxPop;
    }
}
