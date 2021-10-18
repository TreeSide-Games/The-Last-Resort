using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    ObjectPooler objectPooler;
    void Start()
    {
        objectPooler = ObjectPooler.Instance;
        //Destroy(gameObject, 5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Bullet")) return;

        objectPooler.BackToPool(gameObject.name.Split(char.Parse("("))[0], gameObject);
        //Destroy(gameObject);
    }
    private void OnTriggerExit(Collider other)
    {
        objectPooler.BackToPool(gameObject.name.Split(char.Parse("("))[0], gameObject);
    }
}
