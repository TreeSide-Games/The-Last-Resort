using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShootingSystem : MonoBehaviour
{
    public GameObject bulletPrefab;
    public AudioSource soundOfShoot;

    public Vector3 spawnPosition;
    public Vector3 shootDirection;

    private float timeOfLastShoot = 0;
    public float shootPeriod = 1f;
    public int magazineCapacity = 6;
    private int[] amountOfBullets = new int[2];
    private int magazinesID = 0;

    public GameObject bulletsCounter;

    public GameObject pistol;
    public GameObject rifle;

    void Update()
    {
        ChangeWeapon();

        if (Input.GetKey(KeyCode.R))
        {
            amountOfBullets[magazinesID] = magazineCapacity;
            displayAmountOfBulltes();
        }

        if (!Input.GetKey(KeyCode.Mouse0)) return;

        if (amountOfBullets[magazinesID] <= 0) return;

        if (Time.timeSinceLevelLoad - timeOfLastShoot < shootPeriod) return;

        timeOfLastShoot = Time.timeSinceLevelLoad;

        soundOfShoot.Play();
        amountOfBullets[magazinesID]--;
        displayAmountOfBulltes();

        var bullet = Instantiate(bulletPrefab);
        bullet.transform.position = transform.position + transform.rotation * spawnPosition;

        var rigidbody = bullet.GetComponent<Rigidbody>();

        rigidbody.velocity = transform.rotation * shootDirection;
    }

    public void ChangeWeapon()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
           rifle.SetActive(false);
           shootPeriod = 0.5f;
           magazineCapacity = 6;
           magazinesID = 0;
           pistol.SetActive(true);

           displayAmountOfBulltes();
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            rifle.SetActive(true);
            shootPeriod = 0.1f;
            magazineCapacity = 30;
            magazinesID = 1;
            pistol.SetActive(false);

            displayAmountOfBulltes();
        }
    }

    private void displayAmountOfBulltes()
    {
        bulletsCounter.GetComponent<TextMeshProUGUI>().text = amountOfBullets[magazinesID] + "/" + magazineCapacity;
    }
}
