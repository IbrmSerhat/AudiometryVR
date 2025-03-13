using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManagerScript : MonoBehaviour
{
    public GameObject panel1;
    public GameObject panel2;

    public GameObject panelMain1;
    public GameObject panelMain2;


    public void ActivatePanel1()
    {
        panel1.SetActive(true);
        panel2.SetActive(false);
    }

    public void ActivatePanel2()
    {
        panel1.SetActive(false);
        panel2.SetActive(true);
    }

    public void ActivatePanelMain1()
    {
        panelMain1.SetActive(true);
        panelMain2.SetActive(false);
    }

    public void ActivatePanelMain2()
    {
        panelMain1.SetActive(false);
        panelMain2.SetActive(true);
    }

    public void StoryLine1()
    {
        Debug.Log("StoryLine1");
    }

    public void StoryLine2()
    {
        Debug.Log("StoryLine2");
    }

    public void StoryLine3()
    {
        Debug.Log("StoryLine3");
    }
    
    public void XRLevel1()
    {
        Debug.Log("XRLevel1");
    }

    public void ExitButton()
    {
        Debug.Log("Exit");
    }
}
