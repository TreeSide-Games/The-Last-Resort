using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BrutalController : MonoBehaviour
{
    public float lookRadius = 50f;
    public float forwardingRadius = 10f;

    public Transform player;
    public NavMeshAgent agent;

    private Animator animation;

    // Start is called before the first frame update
    public void Start()
    {
        player = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        animation = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    public void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);

        if (distance <= lookRadius)
        {
            agent.SetDestination(player.position);

            if (distance <= forwardingRadius)
            {
                animation.SetFloat("Speed", 2f, 0.1f, Time.deltaTime);
            }
            else
            {
                animation.SetFloat("Speed", 1.2f, 0.1f, Time.deltaTime);
            }
            

            if (distance <= agent.stoppingDistance)
            {
                //Atakuj cel
                FaceTarget();

            }
        }
        else
        {
            animation.SetFloat("Speed", 0f, 0.1f, Time.deltaTime);
        }
    }
    public void FaceTarget()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
