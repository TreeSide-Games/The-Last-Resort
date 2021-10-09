using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI timer;
    public TextMeshProUGUI killsCounter;

    void Start()
    {
        timer.text = "Survived: "+PlayerPrefs.GetString("Time");
        killsCounter.text = PlayerPrefs.GetString("Kills");
    }
}
