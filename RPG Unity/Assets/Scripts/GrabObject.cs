using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObject : MonoBehaviour
{

    GameObject grabbedObject;
    float grabbedObjectSize;
    Rigidbody grabbedObjectRigidBody;

    GameObject GetMouseHoverObject(float range)
    {
        Vector3 position = gameObject.transform.position;
        RaycastHit raycastHit;
        Vector3 target = position + Camera.main.transform.forward * range;

        if (Physics.Linecast(position, target, out raycastHit))
            return raycastHit.collider.gameObject;
        return null;

    }

    void TryGrabObject(GameObject grabObject)
    {
        if (grabObject == null || !CanGrab(grabObject))
            return;
        grabbedObject = grabObject;
        Debug.Log(grabbedObject.ToString());
        grabbedObjectSize = grabObject.GetComponent<Renderer>().bounds.size.magnitude;
        grabbedObjectRigidBody = grabbedObject.GetComponent<Rigidbody>();
    }
    bool CanGrab(GameObject canidate)
    {
        return canidate.GetComponent<Rigidbody>();
    }
    void DropObject()
    {
        if (grabbedObject == null)
            return;


        if (grabbedObject.GetComponent<Rigidbody>() != null)
            grabbedObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        grabbedObject = null;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (grabbedObject == null)
                TryGrabObject(GetMouseHoverObject(5));

            else
                DropObject();
            if (grabbedObjectRigidBody != null)
            {
                if (grabbedObjectRigidBody.freezeRotation == true)
                {
                    grabbedObjectRigidBody.freezeRotation = false;
                }
            }
        }

        if (grabbedObject != null)
        {
            Vector3 newPosition = gameObject.transform.position + Camera.main.transform.forward * grabbedObjectSize;
            grabbedObjectRigidBody.MovePosition(newPosition);
            grabbedObjectRigidBody.freezeRotation = true;
        }

    }
}