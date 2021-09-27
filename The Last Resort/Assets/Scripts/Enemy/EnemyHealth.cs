using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public GameObject bloodParticles;
    public float health = 1f;

    public GameObject brokenObject;
    public float breakForce;

    private void OnCollisionEnter(Collision collision)
    {
        var layerID = collision.collider.gameObject.layer;
        var layerName = LayerMask.LayerToName(layerID);

        switch (layerName)
        {
            case "BulletPistol": health -= 0.25f; releaseBlood(collision); break;
            case "BulletRifle": health -= 0.25f; releaseBlood(collision); break;
            case "BulletBigge": health -= 1.2f; releaseBlood(collision); break;
            default: break;
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

    private void releaseBlood(Collision collision)
    {
        var positionOfCollision = collision.contacts[0].point;
        GameObject blood = Instantiate(bloodParticles, positionOfCollision, Quaternion.identity);
        Destroy(blood, 1f);
    }
}
