using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public GameObject bloodParticles;
    public float health = 2f;

    public GameObject brokenObject;
    public float breakForce;

    private void OnCollisionEnter(Collision collision)
    {
        var layerID = collision.collider.gameObject.layer;
        var layerName = LayerMask.LayerToName(layerID);

        if(layerName == "Bullet")
        {
            health -= 0.5f;

            var positionOfCollision = collision.contacts[0].point;
            Instantiate(bloodParticles, positionOfCollision, Quaternion.identity);
        }

        if(health <= 0)
        {
            Break();
            Destroy(gameObject);
        }
    }

    public void Break()
    {
        GameObject broken = Instantiate(brokenObject, transform.position, transform.rotation);

        foreach (Rigidbody rigidbody in broken.GetComponentsInChildren<Rigidbody>())
        {
            Vector3 force = (rigidbody.transform.position - transform.position).normalized * breakForce;
            rigidbody.AddForce(force);
        }

        Destroy(gameObject);
        Destroy(broken, 20f);
    }
}
