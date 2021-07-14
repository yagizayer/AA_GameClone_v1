using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventController : MonoBehaviour
{
    [SerializeField] private UnityEvent<Transform> PlayerClicked = new UnityEvent<Transform>();
    [SerializeField] private UnityEvent<Transform> PinTouchedTarget = new UnityEvent<Transform>();
    [SerializeField] private UnityEvent PinTouchedPin = new UnityEvent();
    [SerializeField] private UnityEvent GameEnded = new UnityEvent();



    public void InvokePlayerClickEvent()
    {
        PlayerClicked.Invoke(GlobalVariables.GetNextPin());
    }
    public void InvokePinTouchedTargetEvent(Transform pin)
    {
        PinTouchedTarget.Invoke(pin);
    }
    public void InvokePinTouchedPinEvent()
    {
        PinTouchedPin.Invoke();
    }
    public void InvokeGameEndedEvent()
    {
        GameEnded.Invoke();
    }
    public void TestFunc()
    {
        Debug.Log("test");
    }
}
