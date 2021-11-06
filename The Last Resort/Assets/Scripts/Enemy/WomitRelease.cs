using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WomitRelease : StateMachineBehaviour
{
    ObjectPooler objectPooler;
    GameObject ball;

    Transform parentTransform;
    public bool alreadyAttacked;
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        alreadyAttacked = false;
        objectPooler = ObjectPooler.Instance;
        parentTransform = animator.GetComponentInParent<Transform>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.normalizedTime >= 0.33f)
        {
            if (alreadyAttacked) return;

            ball = objectPooler.SpawnFromPool("BallWomiter", parentTransform.parent.position, parentTransform.parent.rotation);
            ball.GetComponent<Rigidbody>().AddForce(ball.transform.forward * 220);

            alreadyAttacked = true;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
