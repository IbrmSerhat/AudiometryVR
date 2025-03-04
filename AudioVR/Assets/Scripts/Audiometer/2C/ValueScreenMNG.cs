using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ValueScreenMNG : MonoBehaviour
{
    //Value Texts
    public TextMeshPro[] TxtDbVal = new TextMeshPro[2];
    public TextMeshPro[] TxtFqVal = new TextMeshPro[2];
    public GameObject[] TxtChVal = new GameObject[2];
    public GameObject[] TxtPresentVal = new GameObject[2];
    //Value Variables
    private int[] DbVal = { 0, 60, 60 };
    private int[] FqPtr = { 0, 4, 4 }; private int[] FqVal = { 125, 250, 500, 750, 1000, 1500, 2000, 3000, 4000, 6000, 8000 };
    private bool[] ChVal = { false, false, false };
    private bool[] PresentVal = { false, false, false }; private bool[] ContVal = { false, false, false };

    void Start()
    {
        
    }

    void Update()
    {
        for(int i = 1; i <= 2; i++)
        {
            TxtDbVal[i - 1].text = DbVal[i].ToString();
            TxtFqVal[i - 1].text = FqVal[FqPtr[i]].ToString();
            TxtChVal[i - 1].SetActive(ChVal[i]);
            TxtPresentVal[i - 1].SetActive(PresentVal[i]); if (!ContVal[i]) PresentVal[i] = false;

        }
    }

    public void DbUp(int Ch) { if (DbVal[Ch] < 130) DbVal[Ch] += 10; }

    public void DbDown(int Ch) { if (-10 < DbVal[Ch]) DbVal[Ch] -= 10; }

    public void FqUp(int Ch) { if (FqPtr[Ch] < 10) FqPtr[Ch]++; }

    public void FqDown(int Ch) { if (0 < FqPtr[Ch]) FqPtr[Ch]--; }

    public void ChangeChVal(int Ch) { ChVal[Ch] = !ChVal[Ch]; }

    public void Present(int Ch) { PresentVal[Ch] = true; }

    public void Cont(int Ch) { ContVal[Ch] = !ContVal[Ch]; }


}
