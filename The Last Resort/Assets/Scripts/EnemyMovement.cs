using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Animator animation;
    void Start()
    {
        animation = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            //Debug.Log("W");
            animation.SetFloat("Speed", 1f, 0.1f, Time.deltaTime);
        }
        else
        {
            animation.SetFloat("Speed", 0f, 0.1f, Time.deltaTime);
        }
    }
}
