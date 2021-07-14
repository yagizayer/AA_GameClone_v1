using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TargetBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject _targetChildren;

    public void ReparentPin(Transform pin)
    {
        pin.SetParent(_targetChildren.transform);
    }
}
