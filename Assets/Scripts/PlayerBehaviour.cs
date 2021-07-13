using System.Collections;
using System.Collections.Generic;
using Helpers;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private bool IsGameRunning = true;
    [SerializeField] private bool _canPlayerMove = false;
    [SerializeField] private bool _breakMovement = false;
    [SerializeField] [Range(.001f, 10f)] private float PinSpeed = 3f;

    [SerializeField] private Transform TargetCircle;

    public bool CanPlayerMove { get => _canPlayerMove; set => _canPlayerMove = value; }
    public bool BreakMovement { get => _breakMovement; set => _breakMovement = value; }

    public void ThrowPin()
    {
        StartCoroutine(PinThrowing(TargetCircle, GlobalVariables.CurrentPin, PinSpeed));
    }

    IEnumerator PinThrowing(Transform target, Transform pin, float speed)
    {
        _canPlayerMove = false;
        float lerpVal = 0;
        Vector3 targetPos = target.position;
        Vector3 pinPos = pin.position;
        while (lerpVal < 1 && !BreakMovement)
        {
            Vector3 lerpPos = Vector3.Lerp(pinPos, targetPos, lerpVal);
            pin.position = lerpPos;
            yield return null;
            lerpVal += Time.deltaTime * speed;
        }
        _canPlayerMove = true;
    }
    
}
