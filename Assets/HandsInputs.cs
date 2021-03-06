﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class HandsInputs : MonoBehaviour {

    public KeyCode debugKey = KeyCode.Q; // Pressed - Pull objects, Release - Push objects.

    public Pusher PusherGO;
    public Puller PullerGO;

    public OVRInput.Controller associatedController;

	// Use this for initialization
	void Start () {
        //Debug.Assert(PusherGO != null && PullerGO != null);
    }

    // Update is called once per frame
    void Update()
    {
        //Pressing handtrigger and not touching the Index trigger will activate pull effect.   
        if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, associatedController) && !OVRInput.Get(OVRInput.Touch.PrimaryIndexTrigger, associatedController))
        {//Pull objects.
            Debug.Log("Pressing hand trigger, and released touch events.");
            PullerGO.Pull();//Run Animation.
        }
        //Uppon NearTouch
        if (OVRInput.GetDown(OVRInput.NearTouch.PrimaryIndexTrigger, associatedController))
        {
            //use force /2 and energy /2
            Debug.Log("NearTouch Down");
        }
        if (OVRInput.GetUp(OVRInput.NearTouch.PrimaryIndexTrigger, associatedController))
        {
            Debug.Log("NearTouch Up");
            //reset to original force / energy rate.
        }
        if (OVRInput.Get(OVRInput.Touch.PrimaryIndexTrigger, associatedController))
        {
            Debug.Log("Touching index trigger");
            PullerGO.Stop();//stop using mana and pulling objects.
        }

        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, associatedController)  && OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger, associatedController) || Input.GetKeyUp(debugKey))
        {
            Debug.Log("Released Index trigger and hand trigger");
            PusherGO.Push();
        }
    }
}
