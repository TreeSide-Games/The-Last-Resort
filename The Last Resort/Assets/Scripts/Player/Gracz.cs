using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class Gracz : MonoBehaviour
{
    public GameObject pasekZycia;
    public AudioSource[] dzwiekObrazen;
    public float zycie = 0.3f;

    public TextMeshProUGUI odliczanieIleZyje;
    public TextMeshProUGUI iloscZabitych;

    private void Start()
    {
        pasekZycia.GetComponent<Slider>().value = zycie;

    }
    public void DodajZycie()
    {
        zycie += 0.5f;
        zycie = Mathf.Clamp(zycie, 0, 1);
        pasekZycia.GetComponent<Slider>().value = zycie;
    }

    public void OdejmijZycie()
    {
        zycie -= 0.3f;
        zycie = Mathf.Clamp(zycie, 0, 1);
        pasekZycia.GetComponent<Slider>().value = zycie;

        var random = Random.Range(0, 2);
        dzwiekObrazen[random].Play();

        if(zycie <= 0)
        {
            PlayerPrefs.SetString("Time", odliczanieIleZyje.text);
            PlayerPrefs.SetString("Kills", iloscZabitych.text);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

}

 