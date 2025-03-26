using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    Animator animator;
    public AnimationManager AnimationManager;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SittingArea"))
        {
            animator.SetTrigger("SitDown");
            transform.rotation = Quaternion.Euler(0, 30, 0);
        }
        else if (other.CompareTag("SittingArea2"))
        {
            animator.SetTrigger("SitDown2");
            transform.rotation = Quaternion.Euler(0, 310, 0);
            AnimationManager.CloseDoor();
        }
        transform.position = other.transform.position;
        other.enabled = false;
    }
}
