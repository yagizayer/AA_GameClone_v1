using UnityEngine;
using System.Collections.Generic;

namespace Helpers
{
    public enum Vector3Values
    {
        X, Y, Z, XY, XZ, YZ, XYZ
    }

    public static class _Extesions
    {
        public static Vector3 Modify(this Vector3 oldValues, Vector3Values axis, float newValue)
        {
            switch (axis)
            {
                case Vector3Values.X:
                    return new Vector3(newValue, oldValues.y, oldValues.z);
                case Vector3Values.Y:
                    return new Vector3(oldValues.x, newValue, oldValues.z);
                case Vector3Values.Z:
                    return new Vector3(oldValues.x, oldValues.y, newValue);
            }
            return oldValues;
        }
        public static Vector3 Modify(this Vector3 oldValues, Vector3Values axis, Vector3 newValues)
        {
            switch (axis)
            {
                case Vector3Values.X:
                    return new Vector3(newValues.x, oldValues.y, oldValues.z);
                case Vector3Values.Y:
                    return new Vector3(oldValues.x, newValues.y, oldValues.z);
                case Vector3Values.Z:
                    return new Vector3(oldValues.x, oldValues.y, newValues.z);
                case Vector3Values.XY:
                    return new Vector3(newValues.x, newValues.y, oldValues.z);
                case Vector3Values.XZ:
                    return new Vector3(newValues.x, oldValues.y, newValues.z);
                case Vector3Values.YZ:
                    return new Vector3(oldValues.x, newValues.y, newValues.z);
                case Vector3Values.XYZ:
                    return newValues;
            }
            return oldValues;
        }
        public static Vector3 toVector3(this Vector2 vector2)
        {
            return new Vector3(vector2.x, vector2.y, 0);
        }
        public static Transform Clear(this Transform transform)
        {
            foreach (Transform child in transform)
            {
                GameObject.Destroy(child.gameObject);
            }
            return transform;
        }
        public static bool HasChild(this Transform transform)
        {
            foreach (Transform child in transform)
                return true;
            return false;
        }
        public static void Reset(this Transform transform)
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.localScale = Vector3.one;
        }
        public static Transform ResetPosition(this Transform transform)
        {
            transform.localPosition = Vector3.zero;
            return transform;
        }
        public static RectTransform Reset(this RectTransform transform)
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.localScale = Vector3.one;
            transform.anchorMin = Vector2.zero;
            transform.anchorMax = Vector2.one;
            transform.sizeDelta = Vector2.zero;
            transform.rect.Set(0, 0, 100, 100);
            return transform;
        }
        public static Dictionary<T1, T2> AddRange<T1, T2>(this Dictionary<T1, T2> me, Dictionary<T1, T2> other)
        {
            foreach (KeyValuePair<T1, T2> item in other)
                me.Add(item.Key, item.Value);
            return me;
        }
        public static Transform LookTarget(this Transform me, Transform target)
        {
            me.rotation = Quaternion.LookRotation(me.position - target.position, Vector3.up);
            return me;
        }
        public static Transform GetFirstChild(this Transform me)
        {
            foreach (Transform item in me)
            {
                return item;
            }
            return null;
        }
        public static Transform GetChildWithTag(this Transform me, string tag)
        {
            foreach (Transform item in me)
                if (item.CompareTag(tag)) return item;
            return null;
        }

        public static Color ModifyA(this Color me, float newValue)
        {
            return new Color(me.r, me.g, me.b, newValue);
        }
    }
}
