using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventController : MonoBehaviour
{
    [SerializeField] private UnityEvent OnLoad = new UnityEvent();
    [SerializeField] private UnityEvent<Transform> PlayerClickedEvent = new UnityEvent<Transform>();
    [SerializeField] private UnityEvent<Transform> PinTouchedTargetEvent = new UnityEvent<Transform>();
    [SerializeField] private UnityEvent<Transform, Transform> PinTouchedPinEvent = new UnityEvent<Transform, Transform>();
    [SerializeField] private UnityEvent<Transform> GameEndedEvent = new UnityEvent<Transform>();

    public void InvokeOnLoadEvent()
    {
        // called in GameField onClick Event
        OnLoad.Invoke();
    }
    public void InvokePlayerClickEvent()
    {
        // called in GameField onClick Event
        Transform currentPin = GlobalVariables.GetNextPin();
        if (currentPin)
            PlayerClickedEvent.Invoke(currentPin);
    }
    public void InvokePinTouchedTargetEvent(Transform pin)
    {
        PinTouchedTargetEvent.Invoke(pin);
    }
    public void InvokePinTouchedPinEvent(Transform me, Transform other)
    {
        PinTouchedPinEvent.Invoke(me, other);
    }
    public void InvokeGameEndedEvent(Transform me)
    {
        if (!GlobalVariables.GameEnded)
        {
            GlobalVariables.GameEnded = true;
            GameEndedEvent.Invoke(me);
        }
    }
    public void TestFunc()
    {
        Debug.Log("test");
    }
}
