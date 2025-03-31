using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMNG : MonoBehaviour
{
    public ValueScreenMNG ValueScreenMNG;
    public AudiogramMNG AudiogramMNG;
    public MarkMNG MarkMNG;

    public HighlightWhenHover[] ContButton = new HighlightWhenHover[2];
    public HighlightWhenHover[] MaskButton = new HighlightWhenHover[2];
    public HighlightWhenHover MicButton;
    public HighlightWhenHover[] PureButton = new HighlightWhenHover[2];
    public HighlightWhenHover[] WarbleButton = new HighlightWhenHover[2];
    public HighlightWhenHover[] WideButton = new HighlightWhenHover[2];
    public HighlightWhenHover[] NarrowButton = new HighlightWhenHover[2];
    public HighlightWhenHover[,] StimButton;
    public HighlightWhenHover[] LeftEButton = new HighlightWhenHover[2];
    public HighlightWhenHover[] RightEButton = new HighlightWhenHover[2];
    public HighlightWhenHover[] BothEButton = new HighlightWhenHover[2];
    public HighlightWhenHover[,] EarButton;

    private int[] CurrStim = { 0, 0, 0 };
    private bool[] CurrMask = { false, false, false };
    private int[] CurrEar = { 0, 0, 1 };

    void Start()
    {
        StimButton = new HighlightWhenHover[2, 4] 
        { 
            { PureButton[0], WarbleButton[0], WideButton[0], NarrowButton[0] }, 
            { PureButton[1], WarbleButton[1], WideButton[1], NarrowButton[1] } 
        };
        EarButton = new HighlightWhenHover[2, 3]
        {
            { LeftEButton[0], RightEButton[0], BothEButton[0] },
            { LeftEButton[1], RightEButton[1], BothEButton[1] }
        };
        StimButton[0, 0].Hold(); StimButton[1, 0].Hold();
        EarButton[0, 0].Hold(); EarButton[1, 1].Hold();
    }

    void Update()
    {
        
    }

    public void DbUp(int Ch)
    {
        ValueScreenMNG.DbUp(Ch);
        AudiogramMNG.DbUp(Ch);
    }

    public void DbDown(int Ch)
    {
        ValueScreenMNG.DbDown(Ch);
        AudiogramMNG.DbDown(Ch);
    }

    public void FqUp(int Ch)
    {
        ValueScreenMNG.FqUp(Ch);
        AudiogramMNG.FqUp(Ch);
    }

    public void FqDown(int Ch)
    {
        ValueScreenMNG.FqDown(Ch);
        AudiogramMNG.FqDown(Ch);
    }

    public void ChangeChVal(int Ch)
    {
        ValueScreenMNG.ChangeChVal(Ch);
    }

    public void Present(int Ch)
    {
        ValueScreenMNG.Present(Ch);
    }

    public void Cont(int Ch)
    {
        ValueScreenMNG.Cont(Ch);
        ContButton[Ch - 1].Hold();
    }

    public void Mic()
    {
        MicButton.Hold();
    }

    public void Mask(int Ch)
    {
        ValueScreenMNG.Mask(Ch);
        MaskButton[Ch - 1].Hold();
        CurrMask[Ch] = !CurrMask[Ch];
        if (CurrStim[Ch] < 2) Stim(Ch, CurrStim[Ch] + 2);
        else Stim(Ch, CurrStim[Ch] - 2);
    }

    public void Td(int Ch)
    {
        ValueScreenMNG.Td(Ch);
    }

    public void Stim(int Num)
    {
        switch (Num)
        {
            case 1:
                Stim(1, 0);
                break;
            case 2:
                Stim(1, 1);
                break;
            case 3:
                Stim(1, 2);
                break;
            case 4:
                Stim(1, 3);
                break;
            case 5:
                Stim(2, 0);
                break;
            case 6:
                Stim(2, 1);
                break;
            case 7:
                Stim(2, 2);
                break;
            case 8:
                Stim(2, 3);
                break;
        }
    }

    public void Stim(int Ch, int WhichStim)
    {
        if (CurrStim[Ch] == WhichStim) return;
        else if ((WhichStim < 2) && (CurrMask[Ch])) return;
        else if ((1 < WhichStim) && (!CurrMask[Ch])) return;
        ValueScreenMNG.Stim(Ch, WhichStim);
        StimButton[Ch - 1, WhichStim].Hold(); StimButton[Ch - 1, CurrStim[Ch]].Hold();
        CurrStim[Ch] = WhichStim;
    }

    public void Ear(int Num)
    {
        switch (Num)
        {
            case 1:
                Ear(1, 0);
                break;
            case 2:
                Ear(1, 1);
                break;
            case 3:
                Ear(1, 2);
                break;
            case 4:
                Ear(2, 0);
                break;
            case 5:
                Ear(2, 1);
                break;
            case 6:
                Ear(2, 2);
                break;
        }
    }

    public void Ear(int Ch, int WhichEar)
    {
        if (CurrEar[Ch] == WhichEar) return;
        ValueScreenMNG.Ear(Ch, WhichEar);
        EarButton[Ch - 1, WhichEar].Hold(); EarButton[Ch - 1, CurrEar[Ch]].Hold();
        CurrEar[Ch] = WhichEar;
    }

    public void Mark(bool didHear)
    {
        MarkMNG.Mark(didHear);
        if (didHear) ValueScreenMNG.MarkToAPI();
    }

}
