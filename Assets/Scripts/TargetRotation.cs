using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetRotation : MonoBehaviour
{
    [Range(-10, 10f)] public float RotateSpeed = 1;
    [SerializeField] private Transform _targetGraphic;
    private void Start()
    {
        StartCoroutine(RotateTarget());
    }
    IEnumerator RotateTarget()
    {
        while (!GlobalVariables.GameEnded)
        {
            _targetGraphic.Rotate(Vector3.forward * RotateSpeed);
            yield return null;
        }
    }

}
