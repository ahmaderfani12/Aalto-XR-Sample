using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameMenuManager : MonoBehaviour
{
    [SerializeField] Transform _head;
    [SerializeField] float _spawnDis = 2;
    [SerializeField] GameObject _menu;
    [SerializeField] InputActionProperty _showMenuButton;


    void Update()
    {
        if (_showMenuButton.action.WasPerformedThisFrame())
        {
            _menu.SetActive(!_menu.activeSelf);
            _menu.transform.position = _head.position + new Vector3(_head.forward.x,0,_head.forward.z).normalized * _spawnDis;
        }

        _menu.transform.LookAt(new Vector3(_head.position.x, _menu.transform.position.y, _head.position.z));
        _menu.transform.forward *= -1;

    }
}
