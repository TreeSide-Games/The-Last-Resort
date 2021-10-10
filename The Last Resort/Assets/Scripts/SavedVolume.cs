using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavedVolume : MonoBehaviour
{
    public AudioSource audio;
    void Start()
    {
        audio.volume = PlayerPrefs.GetFloat("MusicVolume");
    }

}
