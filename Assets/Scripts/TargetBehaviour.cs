using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TargetBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject _targetChildren;

    [SerializeField] public UnityEvent CollisionDetected = new UnityEvent();
    public void ReparentPin()
    {
        GlobalVariables.CurrentPin.SetParent(_targetChildren.transform);
    }
}
