using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinTracker : MonoBehaviour
{

    /* TODO : game manager controls create all Unity events*/
    [SerializeField] private List<GameObject> _allPins = new List<GameObject>();
    public List<GameObject> AllPins { get => _allPins; set => _allPins = value; }
    private int _currentPinNo = 0;

    private void Start()
    {
        ChangeCurrentPin();
    }

    public void ChangeCurrentPin()
    {
        if(_currentPinNo+1 == AllPins.Count) // invoke level end
        GlobalVariables.CurrentPin = AllPins[_currentPinNo++].transform;
    }
}
