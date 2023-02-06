using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;




public class HapticInteractable : MonoBehaviour
{
    public Haptic hapticOnActivated;
    public Haptic hapticHoverEntered;
    public Haptic hapticHoverExited;
    public Haptic hapticSelectEntered;
    public Haptic hapticSelectExited;


    // Start is called before the first frame update
    void Start()
    {
        XRBaseInteractable interactable = GetComponent<XRBaseInteractable>();


        interactable.activated.AddListener(hapticOnActivated.TriggerHaptic);
        interactable.activated.AddListener(hapticHoverEntered.TriggerHaptic);
        interactable.activated.AddListener(hapticHoverExited.TriggerHaptic);
        interactable.activated.AddListener(hapticSelectEntered.TriggerHaptic);
        interactable.activated.AddListener(hapticSelectExited.TriggerHaptic);

    }





}
