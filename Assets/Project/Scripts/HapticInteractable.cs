using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[System.Serializable]
public class Haptic
{
    [Range(0, 1)]
    [SerializeField] float _intensity;
    [SerializeField] float _duration;

    public void TriggerHaptic(BaseInteractionEventArgs arg0)
    {
        if (arg0.interactorObject is XRBaseControllerInteractor controllerInteractor)
        {
            TriggerHaptic(controllerInteractor.xrController);
        }
    }

    private void TriggerHaptic(XRBaseController xrController)
    {
        if (_intensity > 0)
            xrController.SendHapticImpulse(_intensity, _duration);
    }

}

public class HapticInteractable : MonoBehaviour
{
    [SerializeField] Haptic _hapticOnActivated;
    [SerializeField] Haptic _hapticHoverEntered;
    [SerializeField] Haptic _hapticHoverExited;
    [SerializeField] Haptic _hapticSelectEntered;
    [SerializeField] Haptic _hapticSelectExited;

    private void Start()
    {
        XRBaseInteractable interactable = GetComponent<XRBaseInteractable>();

        interactable.activated.AddListener(_hapticOnActivated.TriggerHaptic);
        interactable.hoverEntered.AddListener(_hapticHoverEntered.TriggerHaptic);
        interactable.hoverExited.AddListener(_hapticHoverExited.TriggerHaptic);
        interactable.selectEntered.AddListener(_hapticSelectEntered.TriggerHaptic);
        interactable.selectExited.AddListener(_hapticSelectExited.TriggerHaptic);

    }


}
