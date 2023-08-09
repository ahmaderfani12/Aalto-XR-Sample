using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimateHandOnInput : MonoBehaviour
{
    [SerializeField] InputActionProperty _pinchAnimationAction;
    [SerializeField] InputActionProperty _gripAnimationAction;
    [SerializeField] Animator _handAnimator;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       float triggerValue =  _pinchAnimationAction.action.ReadValue<float>();
       _handAnimator.SetFloat("Trigger",triggerValue);

        float gripValue = _gripAnimationAction.action.ReadValue<float>();
        _handAnimator.SetFloat("Grip", gripValue);
    }
}
