using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingSystem : MonoBehaviour
{
    public GameObject bulletPrefab;
    public AudioSource soundOfShoot;

    public Vector3 spawnPosition;
    public Vector3 shootDirection;

    private float timeOfLastShoot = 0;
    public float shootPeriod = 1f;

    public GameObject pistol;
    public GameObject rifle;

    void Update()
    {
        ChangeWeapon();

        if (!Input.GetKey(KeyCode.Mouse0)) return;

        if (Time.timeSinceLevelLoad - timeOfLastShoot < shootPeriod) return;

        timeOfLastShoot = Time.timeSinceLevelLoad;

        soundOfShoot.Play();

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
           pistol.SetActive(true);
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            rifle.SetActive(true);
            shootPeriod = 0.1f;
            pistol.SetActive(false);
        }
    }
}
