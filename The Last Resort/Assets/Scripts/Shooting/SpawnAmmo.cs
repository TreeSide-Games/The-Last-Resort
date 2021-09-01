using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAmmo : MonoBehaviour
{
    public GameObject[] weapons;
    public float spawnRate = 3f;

    public float minX = 10f;
    public float maxX = 50f;

    public float minZ = 10f;
    public float maxZ = 50f;

    private Vector3 spawnPosition;
    public Material colorOfWeapon;

    private void Start()
    {
        InvokeRepeating("randomSpawn", 3f, spawnRate);
    }

    public void randomSpawn()
    {
        spawnPosition = new Vector3(Random.Range(minX, maxX), 1.51f, Random.Range(minZ, maxZ));

        var random = Random.Range(0, weapons.Length);
        Instantiate(weapons[random], spawnPosition, weapons[random].transform.rotation);
    }
}
