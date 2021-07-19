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
    private Transform _target;
    private _Helper _helper;


    private void Start()
    {
        if (_target == null) _target = GameObject.FindGameObjectWithTag("Target").transform;
        if (_helper == null) _helper = FindObjectOfType<_Helper>();
        if (_eventController == null) _eventController = FindObjectOfType<EventController>();
    }
    public void CreatePins()
    {
        List<Transform> result = new List<Transform>();
        for (int pinNo = 0; pinNo < PinCount; pinNo++)
        {
            GameObject tempPin = Instantiate(PinPrefab, PinsParent);
            tempPin.name = "PinNo" + pinNo.ToString();
            tempPin.GetComponentInChildren<Text>().text = (pinNo + 1).ToString();
            tempPin.transform.position = Vector3.zero + Vector3.down * pinNo + PinsOffset;
            result.Add(tempPin.transform);
        }
        GlobalVariables.AllPins = result;
    }
    public void SlideAllPinsUp()
    {
        List<Transform> first5Pins = new List<Transform>();
        foreach (Transform item in GlobalVariables.AllPins)
        {
            if (item.parent == PinsParent)
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
            StartCoroutine(SlidePinToRestPos(pin, restPos, 5));// burda kaldın
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
        Transform line = pin.GetChildWithTag("Line");
        if (line)
        {
            Image tempImage = line.GetComponent<Image>();
            tempImage.color = tempImage.color.ModifyA(255);
        }
    }
    public void CenterPin(Transform pin)
    {
        pin.position = Vector3.down * .3f;
    }
    public void PaintPinsRed(Transform me, Transform other)
    {
        me.GetComponent<Image>().color = Color.red;
    }

}
