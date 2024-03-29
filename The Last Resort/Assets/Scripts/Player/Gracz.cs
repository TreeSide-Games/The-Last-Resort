using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Gracz : MonoBehaviour
{
    public GameObject pasekZycia;
    public float zycie = 0.3f;

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

        if(zycie <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

}

 