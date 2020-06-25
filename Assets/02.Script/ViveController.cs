using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


public class ViveController : MonoBehaviour
{

    //컨트롤러 정의
    public SteamVR_Input_Sources LeftHand;
    public SteamVR_Input_Sources rightHand;
    public SteamVR_Input_Sources any;

    //컨트롤러 입력값 정ㅇ,ㅣ
    public SteamVR_Action_Boolean trigger;
    public SteamVR_Action_Boolean trackPadClick = SteamVR_Actions.default_Teleport;
    public SteamVR_Action_Boolean trackPadTouch = SteamVR_Actions.default_TrackPadTouch;
    public SteamVR_Action_Vector2 trackPadPositon = SteamVR_Actions.default_TrackPadPosition;

    private SteamVR_Action_Vibration haptic = SteamVR_Actions.default_Haptic;

    void Awake()
    {
        trigger =SteamVR_Actions.default_InteractUI;
    }

    // Update is called once per frame
    void Update()
    {
        


        if (trigger.GetStateDown(LeftHand))
        {
            Debug.Log("Clicked Trigger Button");
            haptic.Execute(0.2f, 0.3f, 120.0f, 0.5f, LeftHand);
        }
        if(trigger.GetStateUp(rightHand))
        {
            Debug.Log("Released Trigger Button");
        }
        if(trackPadClick.GetStateDown(any))
        {
            Debug.Log("TrackPad Click");
        }
        if(trackPadTouch.GetState(any))
        {
            Vector2 pos = trackPadPositon.GetAxis(any);
            Debug.Log($"Touch Pos x = {pos.x}/y = {pos.y}");
        }
        if(trackPadClick.GetStateDown(any))
        {
            Debug.Log("TrackPad Click");
        }


    }
}
