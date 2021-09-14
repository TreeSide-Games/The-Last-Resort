using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject explosionParticle;
    public float explosionRadius = 10f;
    public float explosionForce = 100f;

    public bool canExplode = true;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Bullet") return;

        MakeExplosion();
    }

    public void MakeExplosion()
    {
        if (!canExplode) return;

        Instantiate(explosionParticle, transform.position, transform.rotation);

        Collider[] collidersToBreak = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider nearbyObject in collidersToBreak)
        {
            EnemyHealth destruction = nearbyObject.GetComponent<EnemyHealth>();
            if (destruction != null)
            {
                destruction.Break();
            }
        }

        Collider[] collidersToForce = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider nearbyObject in collidersToForce)
        {
            Rigidbody rigidbody = nearbyObject.GetComponent<Rigidbody>();
            if (rigidbody != null)
            {
                rigidbody.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }
        }

        Collider[] collidersToExplode = Physics.OverlapSphere(transform.position, explosionRadius+2f);

        foreach (Collider nearbyObject in collidersToExplode)
        {
            Explosion secondExplode = nearbyObject.GetComponent<Explosion>();
            if (secondExplode != null && nearbyObject != gameObject.GetComponent<MeshCollider>())
            {
                canExplode = false;
                secondExplode.MakeExplosion();
            }
        }
        Destroy(gameObject);
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
