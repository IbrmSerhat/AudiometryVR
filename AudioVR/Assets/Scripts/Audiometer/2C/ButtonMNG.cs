using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMNG : MonoBehaviour
{
    public ValueScreenMNG ValueScreenMNG;

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
}
