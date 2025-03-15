using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkMNG : MonoBehaviour
{
    public GameObject MarkObjects;
    public AudiogramMNG AudiogramMNG;
    public ValueScreenMNG ValueScreenMNG;

    public GameObject AirL, AirR, AirMaskL, AirMaskR, BoneL, BoneR, BoneMaskL, BoneMaskR, SpeakerL, SpeakerR;
    private GameObject[] WhichObj;

    public GameObject NotAirL, NotAirR, NotAirMaskL, NotAirMaskR, NotBoneL, NotBoneR, NotBoneMaskL, NotBoneMaskR, NotSpeakerL, NotSpeakerR;
    private GameObject[] WhichNotObj;

    void Start()
    {
        WhichObj = new GameObject[10] { AirL, AirR, AirMaskL, AirMaskR, BoneL, BoneR, BoneMaskL, BoneMaskR, SpeakerL, SpeakerR };
        WhichNotObj = new GameObject[10] { NotAirL, NotAirR, NotAirMaskL, NotAirMaskR, NotBoneL, NotBoneR, NotBoneMaskL, NotBoneMaskR, NotSpeakerL, NotSpeakerR };
    }
    void Update()
    {
        
    }

    public void Mark(bool didHear)
    {
        int IconNum = ValueScreenMNG.WhichIcon();
        if (IconNum == 0) return;
        else IconNum--;

        GameObject IconObj;

        if (didHear) IconObj = Instantiate(WhichObj[IconNum], MarkObjects.transform);
        else IconObj = Instantiate(WhichNotObj[IconNum], MarkObjects.transform);

        Vector3 newPosition = IconObj.transform.localPosition;
        newPosition.x += (AudiogramMNG.Get("FQ") - 4f) * 0.07f;
        newPosition.y -= (AudiogramMNG.Get("DB") - 8f) * 0.04f;
        IconObj.transform.localPosition = newPosition;
        IconObj.transform.localRotation = Quaternion.AngleAxis(90, Vector3.right);
        IconObj.transform.localScale = new Vector3(0.35f, 0.35f, 0.35f);

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
}
