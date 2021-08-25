using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public GameObject bloodParticles;
    public float health = 2f;

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
            Destroy(gameObject);
        }
    }
}
