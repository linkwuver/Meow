using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

//attach this script to gameobject to be picked up.
//call disable controller from wherever you want to de-activate the FPS controller.
//make sure box collider istrigger is set to true.

public class DisableFPS : MonoBehaviour //drag and drop FPS controller gameobject in the public fps controller field in the inspector.
{
    public FirstPersonController FPSController;

    void OnTriggerEnter(Collider other)
    {
        //make sure that you set your FPSController object tag (in your hierarchy) to "Player"
        

        if (other.tag == "Player")
        {
            DisableController();
        }
    }

    public void DisableController()
    {
        FPSController.enabled = true;
    }
}