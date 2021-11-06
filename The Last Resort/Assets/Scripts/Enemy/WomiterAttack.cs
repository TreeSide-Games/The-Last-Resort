using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WomiterAttack : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform target;
    private float distance;
    private Animator animation;
    public float attackRadius = 10f;
    public GameObject womitBall;

    private float timeOfLastShoot;
    private float shootPeriod;

    

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = PlayerManager.instance.player.transform;
        animation = GetComponentInChildren<Animator>();
        
        timeOfLastShoot = 0f;
        shootPeriod = 3.3f;
    }


    void Update()
    {
        distance = Vector3.Distance(target.position, transform.position);

        if(distance <= attackRadius)
        {
            FaceTarget();
            if (Time.timeSinceLevelLoad - timeOfLastShoot < shootPeriod) return;

            animation.SetTrigger("Attack");
        }
    }

    public void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }

    /*public IEnumerator shootWomit(float duration)
    {
        float elapse = 0f;
        while(elapse < duration)
        {
            
            elapse += Time.deltaTime;
        }

        timeOfLastShoot = Time.timeSinceLevelLoad;
        

        yield return null;
    }*/
}
