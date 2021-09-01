using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public GameObject timer;
    private void Awake()
    {
        //DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(GameObject.Find("timer"));
    }

    // Update is called once per frame
    void Update()
    {
        timer.GetComponent<TextMeshProUGUI>().text = Mathf.Round(Time.timeSinceLevelLoad) + " s";
    }
}
