using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinCollisionDetection : MonoBehaviour
{
    [SerializeField] private EventController _eventController;

    private void Start()
    {
        if (_eventController == null) _eventController = FindObjectOfType<EventController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Target"))
        {
            _eventController.InvokePinTouchedTargetEvent(transform);
        }
        if (other.CompareTag("Pin"))
        {
            _eventController.InvokePinTouchedPinEvent(transform, other.transform);
        }
    }
}
