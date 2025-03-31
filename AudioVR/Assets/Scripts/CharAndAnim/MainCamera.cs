using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public AnimationManager AnimationManager;
    public APIManager APIManager;
    public Collider FinishTrigger;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("StartTrigger"))
        {
            other.enabled = false;
            AnimationManager.GoToCabin();
            FinishTrigger.enabled = true;
            //ValueScreenManager.TestStarted = true;
        }
        else if (other.CompareTag("FinishTrigger"))
        {
            other.enabled = false;
            AnimationManager.Exit();
            StartCoroutine(APIManager.HandleGetRequest("1"));
            StartCoroutine(APIManager.CallPostTeach(SceneData.myValue));
        }
    }
}
