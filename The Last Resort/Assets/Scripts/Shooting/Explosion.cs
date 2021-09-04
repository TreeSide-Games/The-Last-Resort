using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject explosion;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Bullet") return;

        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
