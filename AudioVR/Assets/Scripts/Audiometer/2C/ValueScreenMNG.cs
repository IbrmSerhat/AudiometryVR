using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ValueScreenMNG : MonoBehaviour
{
    public AudiogramMNG AudiogramMNG;
    public PhoneMNG PhoneMNG;
    public APIManager APIManager;
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
    private int MainCh = 1;

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
            if (ContVal[i]) PresentVal[i] = true;
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

    public void ChangeChVal(int Ch) 
    {
        ChVal[Ch] = !ChVal[Ch];
        AudiogramMNG.SetValues(FindMainCh(), (float)FqPtr[1] + 1f, (float)FqPtr[2] + 1f, ((float)DbVal[1] + 20f) / 10f, ((float)DbVal[2] + 20f) / 10f);
        PhoneMNG.UpdatePhone(MainCh, TdPtr[MainCh]);
    }

    public IEnumerator Present(int Ch) 
    {
        if (!ContVal[Ch])
        {
            PresentVal[Ch] = true;
            yield return new WaitForSeconds(5f);
            PresentVal[Ch] = false;
        }
    }

    public void Cont(int Ch) 
    { 
        ContVal[Ch] = !ContVal[Ch];
        if (!ContVal[Ch]) PresentVal[Ch] = false;
    }

    public void Mask(int Ch)
    {
        MaskVal[Ch] = !MaskVal[Ch];
        AudiogramMNG.SetValues(FindMainCh(), (float)FqPtr[1] + 1f, (float)FqPtr[2] + 1f, ((float)DbVal[1] + 20f) / 10f, ((float)DbVal[2] + 20f) / 10f);
        PhoneMNG.UpdatePhone(MainCh, TdPtr[MainCh]);
    }

    public void Td(int Ch)
    {
        TdPtr[Ch]++;
        if (TdPtr[Ch] == 3) TdPtr[Ch] = 0;
        PhoneMNG.UpdatePhone(MainCh, TdPtr[MainCh]);
    }

    public void Stim(int Ch, int WhichStim)
    {
        StimPtr[Ch] = WhichStim;
    }

    public void Ear(int Ch, int WhichEar)
    {
        EarPtr[Ch] = WhichEar;
    }

    private int FindMainCh()
    {
        if (ChVal[1] ^ ChVal[2])
        {
            if (ChVal[1]) MainCh = 1;
            else MainCh = 2;
        }

        else if (ChVal[1] && ChVal[2])
        {
            if (!(MaskVal[1] && MaskVal[2]))
            {
                if (MaskVal[1]) MainCh = 2;
                else if (MaskVal[2]) MainCh = 1;
                else MainCh = 1;
            }
            else MainCh = 0;
        }

        else MainCh = 0;

        return MainCh;
    }

    public int WhichIcon()
    {
        int IconNum = 0;
        int SideCh = 0;

        if (MainCh == 1) SideCh = 2;
        else if (MainCh == 2) SideCh = 1;
        else if (MainCh == 0) return 0;

        if (EarPtr[MainCh] == 0) IconNum += 1;
        else if (EarPtr[MainCh] == 1) IconNum += 2;
        else return 0;

        if (TdPtr[MainCh] == 0) IconNum += 8;
        else if (TdPtr[MainCh] == 2) IconNum += 4;

        if (ChVal[SideCh] && MaskVal[SideCh]) IconNum += 2;

        if (10 < IconNum) return 0;
        else return IconNum;
    }
    /*
     * 0 OFF
     * 1 Air Left 
     * 2 Air Right
     * 3 Air Left Mask
     * 4 Air Right Mask
     * 5 Bone Left 
     * 6 Bone Right 
     * 7 Bone Left Mask
     * 8 Bone Right Mask
     * 9 Speaker Left
     * 10 Speaker Right
     */

    public void MarkToAPI()
    {
        FindMainCh();

        string EarForAPI = "", PhoneForAPI = "";

        switch (EarPtr[MainCh])
        {
            case 0:
                EarForAPI = "left";
                break;
            case 1:
                EarForAPI = "right";
                break;
            case 2:
                return;
        }

        switch (TdPtr[MainCh])
        {
            case 0:
                return;
            case 1:
                PhoneForAPI = "air";
                break;
            case 2:
                PhoneForAPI = "bone";
                break;
        }

        StartCoroutine(APIManager.HandlePutRequest("1", DbVal[MainCh], EarForAPI, FqVal[FqPtr[MainCh]], PhoneForAPI));
    }
}
