using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManagerScript : MonoBehaviour
{
    public GameObject panel1;
    public GameObject panel2;


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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
