using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShootingSystem : MonoBehaviour
{
    public GameObject[] bulletPrefab;
    public GameObject shootFlashPrefab;
    public AudioSource[] soundOfShoot;
    public AudioSource reloadSound;

    public Vector3 spawnPosition;
    public Vector3 shootDirection;

    private float timeOfLastShoot = 0;
    public float shootPeriod = 1f;
    public int magazineCapacity = 6;
    private int[] amountOfMagazines = new int[5];
    private int[] amountOfBullets = new int[5];
    private int magazinesID = 0;

    public GameObject bulletsCounter;

    public GameObject[] weapons;

    private Magazines magazines;
    private void Start()
    {
        //soundOfShoot = GetComponents<AudioSource>();
        amountOfBullets[0] = 6;
        amountOfBullets[1] = 30;
        amountOfBullets[2] = 4;
        amountOfBullets[3] = 10;
        amountOfBullets[4] = 8;

        amountOfMagazines[0] = 1;
        for (int i = 1; i < 5; i++)
        {
            amountOfMagazines[i] = 3;
        }
        displayAmountOfBulltes();
        magazines = GetComponent<Magazines>();
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

#pragma warning disable CS0612 // Typ lub składowa jest przestarzała
        shootingPlay();
        weapons[magazinesID].GetComponent<Animator>().SetTrigger("Shot");
#pragma warning restore CS0612 // Typ lub składowa jest przestarzała
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
            weapons[0].SetActive(true);
            weapons[1].SetActive(false);
            weapons[2].SetActive(false);
            weapons[3].SetActive(false);
            weapons[4].SetActive(false);

            shootPeriod = 0.5f;
            magazineCapacity = 6;
            magazinesID = 0;

            displayAmountOfBulltes();
            magazines.ChangeMagazine(amountOfMagazines[magazinesID], magazinesID);
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            weapons[0].SetActive(false);
            weapons[1].SetActive(true);
            weapons[2].SetActive(false);
            weapons[3].SetActive(false);
            weapons[4].SetActive(false);

            shootPeriod = 0.1f;
            magazineCapacity = 30;
            magazinesID = 1;

            displayAmountOfBulltes();
            magazines.ChangeMagazine(amountOfMagazines[magazinesID], magazinesID);
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            weapons[0].SetActive(false);
            weapons[1].SetActive(false);
            weapons[2].SetActive(true);
            weapons[3].SetActive(false);
            weapons[4].SetActive(false);

            shootPeriod = 1f;
            magazineCapacity = 4;
            magazinesID = 2;

            displayAmountOfBulltes();
            magazines.ChangeMagazine(amountOfMagazines[magazinesID], magazinesID);
        }
        else if (Input.GetKey(KeyCode.Alpha4))
        {
            weapons[0].SetActive(false);
            weapons[1].SetActive(false);
            weapons[2].SetActive(false);
            weapons[3].SetActive(true);
            weapons[4].SetActive(false);

            shootPeriod = 2f;
            magazineCapacity = 10;
            magazinesID = 3;

            displayAmountOfBulltes();
            magazines.ChangeMagazine(amountOfMagazines[magazinesID], magazinesID);
        }
        else if (Input.GetKey(KeyCode.Alpha5))
        {
            weapons[0].SetActive(false);
            weapons[1].SetActive(false);
            weapons[2].SetActive(false);
            weapons[3].SetActive(false);
            weapons[4].SetActive(true);

            shootPeriod = 0.7f;
            magazineCapacity = 8;
            magazinesID = 4;

            displayAmountOfBulltes();
            magazines.ChangeMagazine(amountOfMagazines[magazinesID], magazinesID);
        }
    }

    public void addMagazine(int typeOfWeapon)
    {
        amountOfMagazines[typeOfWeapon]++;
        if (typeOfWeapon == magazinesID)
        {
            magazines.AddMagazine();
        }
    }

    private void Reload()
    {
        if (amountOfMagazines[magazinesID] < 1) return;
        if (amountOfBullets[magazinesID] == magazineCapacity) return;

        reloadSound.Play();
        if (magazinesID != 0)
        {
            amountOfMagazines[magazinesID]--;
            magazines.RemoveMagazine();
        }
        amountOfBullets[magazinesID] = magazineCapacity;
        displayAmountOfBulltes();
    }
    private void displayAmountOfBulltes()
    {
        bulletsCounter.GetComponent<TextMeshProUGUI>().text = amountOfBullets[magazinesID] + "/" + magazineCapacity;
    }

    [System.Obsolete]
    private void shootingPlay()
    {
        if (weapons[0].active == true)
        {
            soundOfShoot[0].Play();
        }
        else if (weapons[1].active == true)
        {
            soundOfShoot[1].Play();
            
        }
        else if (weapons[2].active == true)
        {
            soundOfShoot[2].Play();
        }
        else if (weapons[3].active == true)
        {
            soundOfShoot[3].Play();
        }
        else
        {
            soundOfShoot[4].Play();
        }
    }

    private void afterShoot()
    {
        transform.Rotate(new Vector3(300f, 0, 0) * Time.deltaTime);
    }

    private void bulletRelease(int typeOfWeapon)
    {
        if(typeOfWeapon != 4)
        {
            var bullet = Instantiate(bulletPrefab[typeOfWeapon]);
        
            bullet.transform.position = transform.position + transform.rotation * spawnPosition;
            bullet.transform.rotation = GetComponentInParent<Gracz>().transform.rotation;

            var rigidbody = bullet.GetComponent<Rigidbody>();

            rigidbody.velocity = transform.rotation * shootDirection;
        }
        else
        {
            GameObject[] bullet = new GameObject[6];
            Rigidbody rigidbody;

            for (int i = 0; i < 6; i++)
            {
                bullet[i] = Instantiate(bulletPrefab[typeOfWeapon]);
                bullet[i].transform.position = transform.position + transform.rotation * spawnPosition;
                bullet[i].transform.rotation = GetComponentInParent<Gracz>().transform.rotation;

                rigidbody = bullet[i].GetComponent<Rigidbody>();

                rigidbody.velocity = transform.rotation * shootDirection * Random.Range(0.1f, 2f);
            }
        }
        
    }
}