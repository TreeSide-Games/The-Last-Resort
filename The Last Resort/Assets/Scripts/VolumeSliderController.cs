using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSliderController : MonoBehaviour
{
    public GameObject[] audioSorce;
    public GameObject parentObject;

    private void Start()
    {
        foreach (var source in audioSorce)
        {
            foreach (var audio in source.GetComponents<AudioSource>())
            {
                audio.volume = PlayerPrefs.GetFloat(parentObject.name);
            }
        }
        GetComponent<Slider>().value = PlayerPrefs.GetFloat(parentObject.name);
    }
    public void OnSliderChanged(float value)
    {
        foreach (var source in audioSorce)
        {
            foreach (var audio in source.GetComponents<AudioSource>())
            {
                audio.volume = value;
            }
        }
        PlayerPrefs.SetFloat(parentObject.name, value);
    }

    
}
