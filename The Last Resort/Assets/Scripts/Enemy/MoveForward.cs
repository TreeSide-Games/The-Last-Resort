using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    ObjectPooler objectPooler;

    void Start()
    {
        objectPooler = ObjectPooler.Instance;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Womiter") return;

        if (collision.collider.name == "Gracz")
        {
            collision.collider.GetComponent<Gracz>().OdejmijZycie();
        }

        objectPooler.BackToPool(gameObject.name.Split(char.Parse("("))[0], gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Womiter") return;

        objectPooler.BackToPool(gameObject.name.Split(char.Parse("("))[0], gameObject);
    }
}
