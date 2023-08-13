using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandData : MonoBehaviour
{
    public enum HandModelType { Left,Right };

    public HandModelType _handModelType;
    public Transform _root;
    public Animator _animator;
    public Transform[] _fingerBones;


}
