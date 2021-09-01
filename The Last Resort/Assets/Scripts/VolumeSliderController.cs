using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSliderController : MonoBehaviour
{
    public AudioSource audio;
    public void OnSliderChanged(float value)
    {
        audio.volume = value;
    }
}
