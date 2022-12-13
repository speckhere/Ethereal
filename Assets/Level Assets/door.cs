using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    [SerializeField]
    private bool _isOpen = false;

    public void OpenDoor()
    {
        _isOpen = true;
        gameObject.SetActive(!_isOpen);
    }

    void Start() {
        _isOpen = false;
        gameObject.SetActive(!_isOpen);
    }
}
