using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShootingSystem : MonoBehaviour
{
    public GameObject[] bulletPrefab;
    public GameObject shootFlashPrefab;
    public AudioSource[] soundOfShoot;

    public Vector3 spawnPosition;
    public Vector3 shootDirection;

    private float timeOfLastShoot = 0;
    public float shootPeriod = 1f;
    public int magazineCapacity = 6;
    private int[] amountOfMagazines = new int[3];
    private int[] amountOfBullets = new int[3];
    private int magazinesID = 0;

    public GameObject bulletsCounter;

    public GameObject pistol;
    public GameObject rifle;
    public GameObject biggun;
    private void Start()
    {
        soundOfShoot = GetComponents<AudioSource>();
        amountOfBullets[0] = 6;
        amountOfBullets[1] = 30;
        amountOfBullets[2] = 3;
        displayAmountOfBulltes();
    }
    void Update()
    {
        ChangeWeapon();

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }

        if (!Input.GetKey(KeyCode.Mouse0)) return;

        if (amountOfBullets[magazinesID] <= 0) return;

        if (Time.timeSinceLevelLoad - timeOfLastShoot < shootPeriod) return;

        timeOfLastShoot = Time.timeSinceLevelLoad;

        shootingPlay();
        amountOfBullets[magazinesID]--;
        displayAmountOfBulltes();

        var shootFlash = Instantiate(shootFlashPrefab);
        shootFlash.transform.position = transform.position + transform.rotation * spawnPosition;

        bulletRelease(magazinesID);

        afterShoot();
    }

    public void ChangeWeapon()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
           pistol.SetActive(true);
           rifle.SetActive(false);
           biggun.SetActive(false);

            shootPeriod = 0.5f;
           magazineCapacity = 6;
           magazinesID = 0;

           displayAmountOfBulltes();
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            pistol.SetActive(false);
            rifle.SetActive(true);
            biggun.SetActive(false);

            shootPeriod = 0.1f;
            magazineCapacity = 30;
            magazinesID = 1;

            displayAmountOfBulltes();
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            pistol.SetActive(false);
            rifle.SetActive(false);
            biggun.SetActive(true);

            shootPeriod = 1f;
            magazineCapacity = 3;
            magazinesID = 2;

            displayAmountOfBulltes();
        }
    }

    public void addMagazine(int typeOfWeapon)
    {
        amountOfMagazines[typeOfWeapon]++;
    }

    private void Reload()
    {
        if (amountOfMagazines[magazinesID] < 1) return;
        if (amountOfBullets[magazinesID] == magazineCapacity) return;

        amountOfMagazines[magazinesID]--;
        amountOfBullets[magazinesID] = magazineCapacity;
        displayAmountOfBulltes();
    }
    private void displayAmountOfBulltes()
    {
        bulletsCounter.GetComponent<TextMeshProUGUI>().text = amountOfBullets[magazinesID] + "/" + magazineCapacity;
    }

    private void shootingPlay()
    {
        if (pistol.active == true)
        {
            soundOfShoot[0].Play();
        }
        else if (rifle.active == true)
        {
            soundOfShoot[1].Play();
        }
        else
        {
            soundOfShoot[2].Play();
        }
    }

    private void afterShoot()
    {
        transform.Rotate(new Vector3(300f, 0, 0) * Time.deltaTime);
    }

    private void bulletRelease(int typeOfWeapon)
    {
        var bullet = Instantiate(bulletPrefab[typeOfWeapon]);
        
        bullet.transform.position = transform.position + transform.rotation * spawnPosition;

        var rigidbody = bullet.GetComponent<Rigidbody>();

        rigidbody.velocity = transform.rotation * shootDirection;
    }
}