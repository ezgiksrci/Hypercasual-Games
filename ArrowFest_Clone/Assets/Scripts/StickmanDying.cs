using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickmanDying : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetTrigger("ArrowShot");
        }
    }
}
