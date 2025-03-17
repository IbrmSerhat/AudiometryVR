using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneMNG : MonoBehaviour
{
    private int LastPhone = 0;

    public GameObject SupraOFF, SupraON, BoneOFF, BoneON;

    void Start()
    {

    }

    void Update()
    {
        
    }

    public void UpdatePhone(int Ch, int Ptr)
    {
        if (Ch == 0) SetPhone(0);

        SetPhone(Ptr);
    }

    private void SetPhone(int Ptr)
    {
        if(LastPhone == Ptr) return;

        if (LastPhone == 1) { SupraON.SetActive(false); SupraOFF.SetActive(true); }
        else if (LastPhone == 2) { BoneON.SetActive(false); BoneOFF.SetActive(true); }

        if (Ptr == 1) { SupraON.SetActive(true); SupraOFF.SetActive(false); }
        else if (Ptr == 2) { BoneON.SetActive(true); BoneOFF.SetActive(false); }

        LastPhone = Ptr;
    }

    /*
     * 0 Speaker
     * 1 Supra
     * 2 Bone
     */
}
