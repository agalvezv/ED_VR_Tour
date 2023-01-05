using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabHandPose : MonoBehaviour
{
    public HandData rightHandPose;

    private Vector3 startingHandP;
    private Vector3 finalHandP;

    private Quaternion startingHandPQ;
    private Quaternion finalHandPQ;

    private Quaternion[] startingFingersRotations;
    private Quaternion[] finalFingersRotations;




    void Start()
    {
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();

        grabInteractable.selectEntered.AddListener(SetupPose);

        grabInteractable.selectExited.AddListener(UnSetupPose);

        rightHandPose.gameObject.SetActive(false);

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetupPose(BaseInteractionEventArgs arg)
    {
        if(arg.interactorObject is XRDirectInteractor)
        {
            HandData handData = arg.interactorObject.transform.GetComponentInChildren<HandData>();
            handData.animator.enabled = false;

            SetHandDataValues(handData, rightHandPose);
            SetHandData(handData, finalHandP, finalHandPQ, finalFingersRotations);
        }
        
    }

    public void UnSetupPose(BaseInteractionEventArgs arg)
    {
        if (arg.interactorObject is XRDirectInteractor)
        {
            HandData handData = arg.interactorObject.transform.GetComponentInChildren<HandData>();
            handData.animator.enabled = true;

            SetHandData(handData, startingHandP, startingHandPQ, startingFingersRotations);
        }

    }

    public void SetHandDataValues(HandData h1, HandData h2)
    {
        //startingHandP = h1.root.localPosition;

        startingHandP = new Vector3(h1.root.localPosition.x / h1.root.localScale.x, h1.root.localPosition.y / h1.root.localScale.y, h1.root.localPosition.z / h1.root.localScale.z);
        
        //finalHandP = h2.root.localPosition;

        finalHandP = new Vector3(h2.root.localPosition.x / h2.root.localScale.x, h2.root.localPosition.y / h2.root.localScale.y, h2.root.localPosition.z / h2.root.localScale.z);

        startingHandPQ = h1.root.localRotation;
        finalHandPQ = h2.root.localRotation;

        startingFingersRotations = new Quaternion[h1.fingerBones.Length];
        finalFingersRotations = new Quaternion[h2.fingerBones.Length];

        for(int i = 0; i < h1.fingerBones.Length; i++)
        {
            startingFingersRotations[i] = h1.fingerBones[i].rotation;
            finalFingersRotations[i] = h2.fingerBones[i].rotation;
        }
    }

    public void SetHandData(HandData h, Vector3 newPosition, Quaternion newRotation, Quaternion[] newBonesRotation)
    {
        h.root.localPosition = newPosition;
        h.root.localRotation = newRotation;

        for (int i = 0; i < newBonesRotation.Length; i++)
        {

            h.fingerBones[i].localRotation = newBonesRotation[i];
        }

    }
}


