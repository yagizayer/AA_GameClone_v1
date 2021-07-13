using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCollisionDetection : MonoBehaviour
{

    [SerializeField] private TargetBehaviour _targetBehaviour;
    private void Start()
    {
        if (_targetBehaviour == null) _targetBehaviour = FindObjectOfType<TargetBehaviour>();
    }
    private void OnTriggerStay(Collider other)
    {
        _targetBehaviour.CollisionDetected.Invoke();
    }
}
