using System.Collections;
using System.Collections.Generic;
using Helpers;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private bool IsGameRunning = true;
    [SerializeField] private bool CanPlayerMove = false;
    [SerializeField] [Range(.001f, 10f)] private float PinSpeed = 3f;

    [SerializeField] private Transform TargetCircle;
    [SerializeField] private Transform CurrentPin;

    [ContextMenu("ThrowPin")]
    public void ThrowPin()
    {
        StartCoroutine(PinThrowing(TargetCircle, CurrentPin, PinSpeed));
    }

    IEnumerator PinThrowing(Transform target, Transform pin, float speed)
    {
        CanPlayerMove = false;
        float lerpVal = 0;
        Vector3 targetPos = target.position;
        Vector3 pinPos = pin.position;
        while (lerpVal < 1 && !CanPlayerMove)
        {
            Vector3 lerpPos = Vector3.Lerp(pinPos, targetPos, lerpVal);
            pin.position = lerpPos;
            yield return null;
            lerpVal += Time.deltaTime * speed;
        }
        CanPlayerMove = true;
    }
}
