using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class GrabHandPos : MonoBehaviour
{

    [SerializeField] HandData _rightHandPos;

    private Vector2 startingHandPosition;
    private Vector3 finalHandPosition;
    private Quaternion startingHandRotation;
    private Quaternion finalHandRotation;

    private List<Quaternion> startingFingerRotations = new List<Quaternion>();
    private List<Quaternion> finalFingerRotations = new List<Quaternion>();

    private void Start()
    {
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();

        grabInteractable.selectEntered.AddListener(SetupPose);
        grabInteractable.selectExited.AddListener(UsSetupPose);

        _rightHandPos.gameObject.SetActive(false);
    }

    private void SetupPose(BaseInteractionEventArgs arg0)
    {
        if(arg0.interactorObject is XRDirectInteractor)
        {
            HandData handData = arg0.interactorObject.transform.GetComponentInChildren<HandData>();
            handData._animator.enabled=false;
            SetHandDataValues(handData, _rightHandPos);
            SetHandData(handData, finalHandPosition, finalHandRotation, finalFingerRotations);

        }
    }

    private void UsSetupPose(BaseInteractionEventArgs arg0)
    {
        if (arg0.interactorObject is XRDirectInteractor)
        {
            HandData handData = arg0.interactorObject.transform.GetComponentInChildren<HandData>();
            handData._animator.enabled = true;

            SetHandData(handData, startingHandPosition, startingHandRotation, startingFingerRotations);
        }
    }

    public void SetHandDataValues(HandData h1, HandData h2)
    {
        startingHandPosition = new Vector3(h1._root.localPosition.x/ h1._root.localScale.x,
            h1._root.localPosition.y / h1._root.localScale.y,
            h1._root.localPosition.z / h1._root.localScale.z);

        finalHandPosition = new Vector3(h2._root.localPosition.x / h2._root.localScale.x,
            h2._root.localPosition.y / h2._root.localScale.y,
            h2._root.localPosition.z / h2._root.localScale.z);

        startingHandRotation = h1._root.localRotation;
        finalHandRotation = h2._root.localRotation;

        startingFingerRotations.Clear();
        finalFingerRotations.Clear();

        for (int i=0; i<h1._fingerBones.Length; i++)
        {
            startingFingerRotations.Add(h1._fingerBones[i].localRotation);
            finalFingerRotations.Add(h2._fingerBones[i].localRotation);
        }
    }

    public void SetHandData(HandData h, Vector3 newPosition, Quaternion newRotation, List<Quaternion> newBonesRotation)
    {
        h._root.localPosition = newPosition;
        h._root.localRotation = newRotation;

        for (int i = 0; i < newBonesRotation.Count; i++)
        {
            h._fingerBones[i].localRotation = newBonesRotation[i];
        }
    }
}
