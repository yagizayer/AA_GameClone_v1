using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Helpers
{
    public class _Helper : MonoBehaviour
    {

        public IEnumerator rotateObject(Transform item, Vector3 rotationAxis, float rotationSpeed, float waveHeight)
        {
            while (true)
            {
                item.Rotate(rotationAxis, 1 * rotationSpeed, Space.Self);
                item.position += Mathf.Sin(Time.time * Mathf.PI) / waveHeight * Vector3.up;
                yield return null;
            }
        }
        public IEnumerator lerpPositions2D(RectTransform objectToLerp, Vector3 startingPos, Vector3 targetPos, float speed=1)
        {

            float lerpVal = 0;
            while (lerpVal < 1)
            {
                objectToLerp.localPosition = Vector3.Lerp(startingPos, targetPos, lerpVal);

                yield return null;
                lerpVal += Time.deltaTime * speed;
            }
        }
        public IEnumerator lerpPositions(Transform objectToLerp, Vector3 startingPos, Vector3 targetPos, float speed = 1)
        {

            float lerpVal = 0;
            while (lerpVal < 1)
            {
                objectToLerp.localPosition = Vector3.Lerp(startingPos, targetPos, lerpVal);

                yield return null;
                lerpVal += Time.deltaTime * speed;
            }
        }

    }
}
