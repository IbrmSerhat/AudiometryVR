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
    public TextMeshPro[] TxtMaskVal = new TextMeshPro[2];
    public TextMeshPro[] TxtTdVal = new TextMeshPro[2];
    public TextMeshPro[] TxtStimVal = new TextMeshPro[2];
    public TextMeshPro[] TxtEarVal = new TextMeshPro[2];
    //Value Variables
    private int[] DbVal = { 0, 60, 60 };
    private int[] FqPtr = { 0, 4, 4 }; private int[] FqVal = { 125, 250, 500, 750, 1000, 1500, 2000, 3000, 4000, 6000, 8000 };
    private bool[] ChVal = { false, true, true };
    private bool[] PresentVal = { false, false, false }; private bool[] ContVal = { false, false, false };
    private bool[] MaskVal = { false, false, false };
    private int[] TdPtr = { 0, 0, 0 }; private string[] TdVal = { "", "SUPRA", "BONE" };
    private int[] StimPtr = { 0, 0, 0 }; private string[] StimVal = { "PURE", "WARBLE", "WIDE BAND", "NARROW BAND" };
    private int[] EarPtr = { 0, 0, 1 }; private string[] EarVal = { "LEFT", "RIGHT", "BOTH" };

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
            TxtPresentVal[i - 1].SetActive(PresentVal[i]);
            if (MaskVal[i]) TxtMaskVal[i - 1].text = "ON"; else TxtMaskVal[i - 1].text = "OFF";
            TxtTdVal[i - 1].text = TdVal[TdPtr[i]];
            TxtStimVal[i - 1].text = StimVal[StimPtr[i]];
            TxtEarVal[i - 1].text = EarVal[EarPtr[i]];
        }
    }

    public void DbUp(int Ch) { if (DbVal[Ch] < 130) DbVal[Ch] += 10; }

    public void DbDown(int Ch) { if (-10 < DbVal[Ch]) DbVal[Ch] -= 10; }

    public void FqUp(int Ch) { if (FqPtr[Ch] < 10) FqPtr[Ch]++; }

    public void FqDown(int Ch) { if (0 < FqPtr[Ch]) FqPtr[Ch]--; }

    public void ChangeChVal(int Ch) { ChVal[Ch] = !ChVal[Ch]; }

    public void Present(int Ch) 
    {
        if (!ContVal[Ch])
        {
            PresentVal[Ch] = true;
            //WAIT COMMAND
            PresentVal[Ch] = false;
        }
    }

    public void Cont(int Ch) 
    { 
        ContVal[Ch] = !ContVal[Ch];
        if(ContVal[Ch]) PresentVal[Ch] = true;
        else PresentVal[Ch] = false;
    }

    public void Mask(int Ch)
    {
        MaskVal[Ch] = !MaskVal[Ch];
    }

    public void Td(int Ch)
    {
        TdPtr[Ch]++;
        if (TdPtr[Ch] == 3) TdPtr[Ch] = 0;
    }

    public void Stim(int Ch, int WhichStim)
    {
        StimPtr[Ch] = WhichStim;
    }

    public void Ear(int Ch, int WhichEar)
    {
        EarPtr[Ch] = WhichEar;
    }

}
