using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public void CheckGameEnd(Transform pin)
    {
        if (pin.GetComponentInChildren<Text>().text == (GlobalVariables.AllPins.Count).ToString())
        {
            Debug.Log("GameEnded");
        }
    }
}
