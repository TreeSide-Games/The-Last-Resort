using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject explosionParticle;
    public float explosionRadius = 5f;
    public float explosionForce = 100f;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Bullet") return;

        MakeExplosion();
    }

    public void MakeExplosion()
    {
        Instantiate(explosionParticle, transform.position, transform.rotation);

        Collider[] collidersToBreak = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider nearbyObject in collidersToBreak)
        {
            EnemyHealth destruction = nearbyObject.GetComponent<EnemyHealth>();
            if (destruction != null)
            {
                destruction.Break();
            }
            //Explosion explode = nearbyObject.GetComponent<Explosion>();
            //if(explode != null)
            //{
            //    explode.MakeExplosion();
            //}
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

        Destroy(gameObject);
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
