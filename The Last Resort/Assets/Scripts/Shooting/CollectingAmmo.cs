using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectingAmmo : MonoBehaviour
{
    public int typeOfWeapon;

    ObjectPooler objectPooler;

    private void Start()
    {
        objectPooler = ObjectPooler.Instance;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name != "Gracz") return;

        GetComponent<AudioSource>().Play();

        other.GetComponentInChildren<ShootingSystem>().addMagazine(typeOfWeapon);

        switch (typeOfWeapon)
        {
            case 1:
                objectPooler.BackToPool("Rifle", gameObject); 
                break;
            case 2:
                objectPooler.BackToPool("Bigge", gameObject);
                break;
            case 3:
                objectPooler.BackToPool("Bazooka", gameObject);
                break;
            case 4:
                objectPooler.BackToPool("Shotgun", gameObject);
                break;
            default: break;
        }

        gameObject.SetActive(false);
        //Destroy(gameObject, 0.5f);
    }
}
