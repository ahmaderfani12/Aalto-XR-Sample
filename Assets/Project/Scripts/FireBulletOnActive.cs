using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireBulletOnActive : MonoBehaviour
{
    [SerializeField] GameObject _bullet;
    [SerializeField] Transform _spawnPoint;
    [SerializeField] float _fireSpeed = 20;

    private void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(FireBullet);
    }

    private void FireBullet(ActivateEventArgs arg0)
    {
        var clone = Instantiate(_bullet, _spawnPoint.position, Quaternion.identity);
        clone.GetComponent<Rigidbody>().velocity = _spawnPoint.forward * _fireSpeed;
        Destroy(clone, 5);
    }

}
