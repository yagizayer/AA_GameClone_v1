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

    [SerializeField] private Transform[] RestingPositions;
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
        Debug.Log("slide first 5 Not Thrown Pin to next rest position here");
        List<Transform> first5Pins = new List<Transform>();
        foreach (Transform item in GlobalVariables.AllPins)
        {
            if (!GlobalVariables.ThrownPins.Contains(item))
            {
                // not thrown all pins
                int currentIndex = GlobalVariables.AllPins.IndexOf(item);
                first5Pins.Add(item);
            }
            if (first5Pins.Count == 5) break;
        }
        for (int i = 0; i < first5Pins.Count; i++)
        {
            Transform pin = first5Pins[i];
            Transform restPos = RestingPositions[i];
            // pin.position = restPos.position;
            StartCoroutine(SlidePinToRestPos(pin, restPos, 2));// burda kaldın
        }
    }

    private IEnumerator SlidePinToRestPos(Transform pin, Transform restPos, float slidingSpeed)
    {
        Vector3 pinPos = pin.position;
        Vector3 restPosTemp = restPos.position;
        float lerpVal = 0;
        while (lerpVal <= 1)
        {
            pin.position = Vector3.Lerp(pinPos, restPosTemp, lerpVal);
            lerpVal += Time.deltaTime * slidingSpeed;
            yield return null;
        }
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
