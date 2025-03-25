using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnim : MonoBehaviour
{
    public GameObject door;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Fatma")
        {
            door.GetComponent<Animator>().SetTrigger("Open");
        }   
    }

    // check for colider stay event
    // if "Fatma" tag is in the collider, trigger to animation
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Fatma")
        {
            door.GetComponent<Animator>().SetTrigger("Open");
        }
    }

    // check for colider exit event
    // if "Fatma" tag is in the collider, trigger to animation
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Fatma")
        {
            door.GetComponent<Animator>().SetTrigger("Close");
        }
    }

}
