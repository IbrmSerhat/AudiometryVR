using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudiogramMNG : MonoBehaviour
{
    public GameObject VerticalPin, HorizontalPin;
    private float vertPtr = 4f, horzPtr = 8f;
    private int MainCh = 1;

    public void FqUp(int Ch)
    {
        if (MainCh == Ch)
        {
            if (3 <= vertPtr && vertPtr < 7)
            {
                Vector3 newPosition = VerticalPin.transform.localPosition;
                newPosition.x += 0.035f;
                VerticalPin.transform.localPosition = newPosition;
                vertPtr += 0.5f;
            }
            else if (vertPtr < 3)
            {
                Vector3 newPosition = VerticalPin.transform.localPosition;
                newPosition.x += 0.07f;
                VerticalPin.transform.localPosition = newPosition;
                vertPtr++;
            }
        }
    }

    public void FqDown(int Ch)
    {
        if (MainCh == Ch)
        {
            if (3 < vertPtr)
            {
                Vector3 newPosition = VerticalPin.transform.localPosition;
                newPosition.x -= 0.035f;
                VerticalPin.transform.localPosition = newPosition;
                vertPtr -= 0.5f;
            }
            else if (1 < vertPtr && vertPtr <= 3)
            {
                Vector3 newPosition = VerticalPin.transform.localPosition;
                newPosition.x -= 0.07f;
                VerticalPin.transform.localPosition = newPosition;
                vertPtr--;
            }
        }
    }

    public void DbUp(int Ch)
    {
        if (MainCh == Ch)
        {
            if (horzPtr < 15)
            {
                Vector3 newPosition = HorizontalPin.transform.localPosition;
                newPosition.y -= 0.04f;
                HorizontalPin.transform.localPosition = newPosition;
                horzPtr++;
            }
        }
    }

    public void DbDown(int Ch)
    {
        if (MainCh == Ch)
        {
            if (1 < horzPtr)
            {
                Vector3 newPosition = HorizontalPin.transform.localPosition;
                newPosition.y += 0.04f;
                HorizontalPin.transform.localPosition = newPosition;
                horzPtr--;
            }
        }
    }

    public void SetDB(float Value)
    {
        if (horzPtr < Value) while (horzPtr < Value) DbUp(MainCh);
        else if (Value < horzPtr) while (Value < horzPtr) DbDown(MainCh);
    }

    public void SetFQ(float Value)
    {
        if (vertPtr < Value) while (vertPtr < Value) FqUp(MainCh);
        else if (Value < vertPtr) while (Value < vertPtr) FqDown(MainCh);
    }

    public void SetValues(bool Ch1, bool Ch2, bool Mask1, bool Mask2, int FqPtr1, int FqPtr2, int DbPtr1, int DbPtr2)
    {
        if (Ch1 ^ Ch2)
        {
            if (Ch1)
            {
                SetDB(DbPtr1);
                SetFQ(FqPtr1);
                MainCh = 1;
            }
            else
            {
                SetDB(DbPtr2);
                SetFQ(FqPtr2);
                MainCh = 2;
            }
        }

        else if (Ch1 && Ch2)
        {
            if (Mask1)
            {
                SetDB(DbPtr2);
                SetFQ(FqPtr2);
                MainCh = 2;
            }
            else if (Mask2)
            {
                SetDB(DbPtr1);
                SetFQ(FqPtr1);
                MainCh = 1;
            }
            else
            {
                SetDB(DbPtr1);
                SetFQ(FqPtr1);
                MainCh = 1;
            }
        }

        else
        {
            SetDB(8f);
            SetFQ(4f);
            MainCh = 0;
        }
    }

}
