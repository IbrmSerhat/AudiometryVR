using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMNG : MonoBehaviour
{
    public ValueScreenMNG ValueScreenMNG;
    public HighlightWhenHover[] ContButton = new HighlightWhenHover[2];

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void DbUp(int Ch)
    {
        ValueScreenMNG.DbUp(Ch);
    }

    public void DbDown(int Ch)
    {
        ValueScreenMNG.DbDown(Ch);
    }

    public void FqUp(int Ch)
    {
        ValueScreenMNG.FqUp(Ch);
    }

    public void FqDown(int Ch)
    {
        ValueScreenMNG.FqDown(Ch);
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
        ContButton.OriginalColor = Color.blue;
    }

}
