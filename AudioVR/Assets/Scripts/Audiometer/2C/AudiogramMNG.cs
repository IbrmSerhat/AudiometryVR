using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudiogramMNG : MonoBehaviour
{
    public GameObject VerticalPin, HorizontalPin;
    private float FqPtr = 4f, DbPtr = 8f;
    private int MainCh = 1;

    public void FqUp(int Ch)
    {
        if (MainCh != Ch) return;

        if (3 <= FqPtr && FqPtr < 7)
        {
            Vector3 newPosition = VerticalPin.transform.localPosition;
            newPosition.x += 0.035f;
            VerticalPin.transform.localPosition = newPosition;
            FqPtr += 0.5f;
        }
        else if (FqPtr < 3)
        {
            Vector3 newPosition = VerticalPin.transform.localPosition;
            newPosition.x += 0.07f;
            VerticalPin.transform.localPosition = newPosition;
            FqPtr++;
        }
    }

    public void FqDown(int Ch)
    {
        if (MainCh != Ch) return;

        if (3 < FqPtr)
        {
            Vector3 newPosition = VerticalPin.transform.localPosition;
            newPosition.x -= 0.035f;
            VerticalPin.transform.localPosition = newPosition;
            FqPtr -= 0.5f;
        }
        else if (1 < FqPtr && FqPtr <= 3)
        {
            Vector3 newPosition = VerticalPin.transform.localPosition;
            newPosition.x -= 0.07f;
            VerticalPin.transform.localPosition = newPosition;
            FqPtr--;
        }
    }

    public void DbUp(int Ch)
    {
        if (MainCh != Ch) return;

        if (DbPtr < 15)
        {
            Vector3 newPosition = HorizontalPin.transform.localPosition;
            newPosition.y -= 0.04f;
            HorizontalPin.transform.localPosition = newPosition;
            DbPtr++;
        }
    }

    public void DbDown(int Ch)
    {
        if (MainCh != Ch) return;

        if (1 < DbPtr)
        {
            Vector3 newPosition = HorizontalPin.transform.localPosition;
            newPosition.y += 0.04f;
            HorizontalPin.transform.localPosition = newPosition;
            DbPtr--;
        }
    }

    public void SetDB(float Value)
    {
        if (DbPtr < Value) while (DbPtr < Value) DbUp(MainCh);
        else if (Value < DbPtr) while (Value < DbPtr) DbDown(MainCh);
    }

    public void SetFQ(float Value)
    {
        if (FqPtr < Value) while (FqPtr < Value) FqUp(MainCh);
        else if (Value < FqPtr) while (Value < FqPtr) FqDown(MainCh);
    }

    public void SetValues(int WhichCh, float FqPtr1, float FqPtr2, float DbPtr1, float DbPtr2)
    {
        if (WhichCh == MainCh) return;

        if (3 < FqPtr1) FqPtr1 = 3f + (FqPtr1 - 3f) / 2f;
        if (3 < FqPtr2) FqPtr2 = 3f + (FqPtr2 - 3f) / 2f;

        MainCh = WhichCh;
        if(MainCh == 1)
        {
            SetDB(DbPtr1);
            SetFQ(FqPtr1);
        }
        else if(MainCh == 2)
        {
            SetDB(DbPtr2);
            SetFQ(FqPtr2);
        }
        else
        {
            SetDB(8f);
            SetFQ(4f);
        }
    }

    public float Get(string DBorFQ)
    {
        if (DBorFQ == "DB") return DbPtr;
        else if (DBorFQ == "FQ") return FqPtr;
        else return 0;
    }

}
