using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject TargetCircle;
    [SerializeField] private SphereCollider TargetCollider;

    private void Start()
    {
        if (TargetCollider == null) TargetCircle.GetComponent<SphereCollider>();
    }

    private void OnTriggerStay(Collider other) {
        Debug.Log("asdasd");
    }
}
