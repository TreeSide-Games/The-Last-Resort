using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public GameObject endInformation;
    public GameObject levelInformation;

    bool isFinished = false;

    private void Start()
    {
        isFinished = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.GetComponent<Gracz>()) return;

        if (FindObjectOfType<KillsCounter>().getZombieKill() >= 10)
        {
            endInformation.SetActive(true);
            isFinished = true;
        }
        else
        {
            levelInformation.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.GetComponent<Gracz>()) return;

        levelInformation.SetActive(false);
    }

    private void Update()
    {
        if(isFinished && Input.anyKeyDown)
        {
            SceneManager.LoadScene(0);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
