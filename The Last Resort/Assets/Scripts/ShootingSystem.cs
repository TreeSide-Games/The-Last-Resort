using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingSystem : MonoBehaviour
{
    public GameObject bulletPrefab;

    public Vector3 spawnPosition;
    public Vector3 shootDirection;
 
    void Update()
    {
        if (!Input.GetKey(KeyCode.Mouse0)) return;

        var bullet = Instantiate(bulletPrefab);
        bullet.transform.position = transform.position + transform.rotation * spawnPosition;

        var rigidbody = bullet.GetComponent<Rigidbody>();

        rigidbody.velocity = transform.rotation * shootDirection;

        Destroy(bullet, 2f);
    }
}
