using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PinManagement : MonoBehaviour
{
    [SerializeField] private Transform PinsParent;
    [SerializeField] private GameObject PinPrefab;
    [SerializeField] private EventController _eventController;
    [SerializeField] [Range(.01f, 100f)] private int PinCount = 10;
    [SerializeField] private Vector3 PinsOffset = Vector3.down * 2;
    private List<Transform> _allPins;
    private void Start()
    {
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

    public void ConnectPinToTarget(Transform pin)
    {
        Debug.Log("connect pin to target with line here");
    }
}
