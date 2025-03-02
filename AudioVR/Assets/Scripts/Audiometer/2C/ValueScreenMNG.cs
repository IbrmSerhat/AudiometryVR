using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ValueScreenMNG : MonoBehaviour
{
    //Value Texts
    public TextMeshPro[] TxtDbVal = new TextMeshPro[2];
    //Value Variables
    private int[] DbVal = new int[3] {0, 60, 60};

    void Start()
    {
        
    }

    void Update()
    {
        for(int i = 1; i <= 2; i++)
        {
            TxtDbVal[i-1].text = DbVal[i].ToString();
        }
    }

    public void DbUp(int Ch) { DbVal[Ch] += 10; }

    public void DbDown(int Ch) { DbVal[Ch] -= 10; }


}
