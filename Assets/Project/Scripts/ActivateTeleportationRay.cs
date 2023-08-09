using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ActivateTeleportationRay : MonoBehaviour
{

    [SerializeField] GameObject _leftTeleportation;
    [SerializeField] GameObject _rightTeleportation;

    [SerializeField] InputActionProperty _leftActivate;
    [SerializeField] InputActionProperty _rightActivate;

    [SerializeField] InputActionProperty _leftCancel;
    [SerializeField] InputActionProperty _rightCancel;

    [SerializeField] XRRayInteractor _leftRay;
    [SerializeField] XRRayInteractor _rightRay;

    private void Update()
    {
        bool isLeftRayHovering = _leftRay.TryGetHitInfo(out Vector3 posL, out Vector3 normalL, out int numL, out bool isValidL);

        _leftTeleportation.SetActive(!isLeftRayHovering &&
            _leftCancel.action.ReadValue<float>()==0 &&
            _leftActivate.action.ReadValue<float>() > 0.1f);

        bool isRightRayHovering = _rightRay.TryGetHitInfo(out Vector3 posR, out Vector3 normalR, out int numR, out bool isValidR);

        _rightTeleportation.SetActive(!isRightRayHovering &&
            _rightCancel.action.ReadValue<float>() == 0 && 
            _rightActivate.action.ReadValue<float>() > 0.1f);

    }

}
