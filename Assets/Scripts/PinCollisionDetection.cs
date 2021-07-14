using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinCollisionDetection : MonoBehaviour
{
    [SerializeField] private EventController _eventController;
    private PinManagement _pinManagement;
    private void Start()
    {
        if (_eventController == null) _eventController = FindObjectOfType<EventController>();
        _pinManagement = FindObjectOfType<PinManagement>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Target"))
        {
            _eventController.InvokePinTouchedTargetEvent(transform);
        }
        if (other.CompareTag("Pin"))
        {
            _eventController.InvokePinTouchedPinEvent();
        }
    }
}
