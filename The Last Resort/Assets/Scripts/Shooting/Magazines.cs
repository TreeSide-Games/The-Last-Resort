using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Magazines : MonoBehaviour
{
    public Slider sliderOfMagazines;
    public Sprite[] bulletImage;
    public Image sliderFill;

    public void Start()
    {
        sliderFill = sliderOfMagazines.transform.GetChild(0).gameObject.GetComponentInChildren<Image>();
    }
    public void ChangeMagazine(int amount, int type)
    {
        sliderOfMagazines.value = type == 0 ? 5 : amount;
        
        sliderFill.sprite = bulletImage[type];
    }

    public void AddMagazine()
    {
        if (sliderOfMagazines.value > 5) return;

        sliderOfMagazines.value++;
    }

    public void RemoveMagazine()
    {
        sliderOfMagazines.value--;
    }
}
