using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalVariables
{
    public static List<Transform> AllPins;
    public static int CurrentPinNo = -1;


    static public Transform GetNextPin()
    {
        if (GlobalVariables.CurrentPinNo + 1 == GlobalVariables.AllPins.Count) return null;
        return GlobalVariables.AllPins[++GlobalVariables.CurrentPinNo];
    }
}