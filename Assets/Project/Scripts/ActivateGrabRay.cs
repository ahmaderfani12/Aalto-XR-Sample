using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ActivateGrabRay : MonoBehaviour
{
    [SerializeField] GameObject _leftGrabRay;
    [SerializeField] GameObject _rightGrabRay;

    [SerializeField] XRDirectInteractor _leftDirectGrab;
    [SerializeField] XRDirectInteractor _rightDirectGrab;


    // Disable Grab Ryas when Holding 
    private void Update()
    {
        _leftGrabRay.SetActive(_leftDirectGrab.interactablesSelected.Count == 0);
        _rightGrabRay.SetActive(_rightDirectGrab.interactablesSelected.Count == 0);
    }
}
