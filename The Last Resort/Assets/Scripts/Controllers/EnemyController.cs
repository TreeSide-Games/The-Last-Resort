using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10f;

<<<<<<< Updated upstream
    public Transform target;
    public NavMeshAgent agent;
=======
    Transform target;
    NavMeshAgent agent;
    private Animator animation;
>>>>>>> Stashed changes

    // Start is called before the first frame update
    public void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    public void Update()
    {
<<<<<<< Updated upstream
        float distance = Vector2.Distance(target.position, transform.position);
=======
        float distance = Vector3.Distance(target.position, transform.position);
>>>>>>> Stashed changes

        if(distance <= lookRadius)
        {
            agent.SetDestination(target.position);
<<<<<<< Updated upstream

            if(distance <= agent.stoppingDistance)
            {
                Facetarget();
=======
            if (distance <= agent.stoppingDistance)
            {
                //Atakuj cel
                FaceTarget();
>>>>>>> Stashed changes
            }
        }
    }

<<<<<<< Updated upstream
    public void Facetarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 16f);
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
=======
    public void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        animation.SetFloat("Speed", 1f, 0.1f, Time.deltaTime);

    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);

>>>>>>> Stashed changes
    }
}
