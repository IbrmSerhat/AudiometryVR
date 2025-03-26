using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimationManager : MonoBehaviour
{
    public Transform OfficePatientChair, CabinChair, Door;
    public NavMeshAgent agent;
    public Animator animator;
    public GameObject DoorClosed, DoorOpened;

    void Start()
    {
        agent.SetDestination(OfficePatientChair.position);
    }

    public void GoToCabin()
    {
        animator.SetTrigger("doktorunyanindankalk");
        agent.SetDestination(CabinChair.position);
    }
    public void Exit()
    {
        animator.SetTrigger("kapiyaGit");
        agent.SetDestination(Door.position);
        OpenDoor();
    }
    public void HandUp()
    {
        animator.SetTrigger("hizliEl");
        animator.SetTrigger("SitDown");
    }
    public void HandSlow()
    {
        animator.SetTrigger("yavasEl");
        animator.SetTrigger("SitDown");
    }

    public void OpenDoor()
    {
        DoorClosed.SetActive(false);
        DoorOpened.SetActive(true);
    }

    public void CloseDoor()
    {
        DoorClosed.SetActive(true);
        DoorOpened.SetActive(false);
    }
}
