using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectingAmmo : MonoBehaviour
{
    public int typeOfWeapon;
    private void OnTriggerEnter(Collider other)
    {
        if (other.name != "Gracz") return;

        GetComponent<AudioSource>().Play();

        other.GetComponentInChildren<ShootingSystem>().addMagazine(typeOfWeapon);
        Destroy(gameObject, 0.5f);
    }
}
