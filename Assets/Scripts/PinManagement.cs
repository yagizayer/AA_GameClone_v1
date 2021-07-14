using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Helpers;

public class PinManagement : MonoBehaviour
{
    [Header("Pin Creation")]
    [SerializeField] [Range(.01f, 100f)] private int PinCount = 10;
    [SerializeField] private Vector3 PinsOffset = Vector3.down * 2;
    [Space(10)]
    [SerializeField] private EventController _eventController;
    [SerializeField] private Transform MidAirPinsParent;
    [SerializeField] private Transform PinsParent;
    [SerializeField] private GameObject PinPrefab;
    private List<Transform> _allPins;
    private _Helper _helper;
    private void Start()
    {
        if (_helper == null) _helper = FindObjectOfType<_Helper>();
        if (_eventController == null) _eventController = FindObjectOfType<EventController>();
        _allPins = CreatePins(PinPrefab, PinCount);
        GlobalVariables.AllPins = _allPins;
    }

    private List<Transform> CreatePins(GameObject pinPrefab, int pinCount)
    {
        List<Transform> result = new List<Transform>();
        for (int pinNo = 0; pinNo < pinCount; pinNo++)
        {
            GameObject tempPin = Instantiate(pinPrefab, PinsParent);
            tempPin.name = "PinNo" + pinNo.ToString();
            tempPin.GetComponentInChildren<Text>().text = (pinNo + 1).ToString();
            tempPin.transform.position = Vector3.zero + Vector3.down * pinNo + PinsOffset;
            result.Add(tempPin.transform);
        }
        return result;
    }

    public void SlideAllPinsUp()
    {
        StartCoroutine(_helper.lerpPositions(PinsParent, PinsParent.localPosition, PinsParent.localPosition + PinsOffset * -150, 5));
    }

    public void DeparentThrownPin(Transform pin)
    {
        pin.SetParent(MidAirPinsParent);
    }

    public void ConnectPinToTarget(Transform pin)
    {
        Debug.Log("connect pin to target with line here");
    }
}
