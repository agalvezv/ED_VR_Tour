using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XROffsetGrabInteractable : XRGrabInteractable
{

    private Vector3 initiallP;
    private Quaternion initiallR;

    // Start is called before the first frame update
    void Start()
    {
        if(!attachTransform)
        {
            GameObject attachPoint = new GameObject("Offset Grab Pivot");

            attachPoint.transform.SetParent(transform, false);
            attachTransform = attachPoint.transform;
        }
        else
        {
            initiallP = attachTransform.localPosition;
            initiallR = attachTransform.localRotation;
        }



        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        if(args.interactorObject is XRDirectInteractor)
        {
            attachTransform.position = args.interactorObject.transform.position;
            attachTransform.rotation = args.interactorObject.transform.rotation;


        }
        else
        {
            attachTransform.localPosition = initiallP;
            attachTransform.rotation = initiallR;

        }

        base.OnSelectEntered(args); 

    }
}
