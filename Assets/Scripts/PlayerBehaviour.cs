using System.Collections;
using System.Collections.Generic;
using Helpers;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] [Range(.001f, 10f)] private float PinSpeed = 3f;
    [SerializeField] private Transform TargetCircle;

    public void ThrowPin()
    {
        StartCoroutine(PinThrowing(TargetCircle, GlobalVariables.GetNextPin(), PinSpeed));
    }

    IEnumerator PinThrowing(Transform target, Transform pin, float speed)
    {
        float lerpVal = 0;
        Vector3 targetPos = target.position;
        Vector3 pinPos = pin.position;
        while (lerpVal < 1)
        {
            Vector3 lerpPos = Vector3.Lerp(pinPos, targetPos, lerpVal);
            pin.position = lerpPos;
            yield return null;
            lerpVal += Time.deltaTime * speed;
        }
    }

    public void BreakMovement(Transform pin)
    {
        StopCoroutine(PinThrowing(TargetCircle, pin, PinSpeed));
    }

}
