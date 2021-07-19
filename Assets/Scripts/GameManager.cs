using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private EventController _eventController;
    [SerializeField] private GameObject FailScreen;
    [SerializeField] private GameObject LevelClearScreen;
    private void Start()
    {
        if (_eventController == null) _eventController = FindObjectOfType<EventController>();
        else _eventController.InvokeOnLoadEvent();
    }

    public void ResetGlobals()
    {
        GlobalVariables.AllPins = new List<Transform>();
        GlobalVariables.CurrentPinNo = -1;
        GlobalVariables.ThrownPins = new List<Transform>();
        GlobalVariables.GameEnded = false;
        GlobalVariables.LevelFailed = false;
    }

    public void CheckGameEnd(Transform pin)
    {
        if (pin.GetComponentInChildren<Text>().text == (GlobalVariables.AllPins.Count).ToString())
        {
            GlobalVariables.LevelFailed = false;
            _eventController.InvokeGameEndedEvent(pin);
        }
    }
    public void GameFailed(Transform me, Transform other)
    {
        GlobalVariables.LevelFailed = true;
        _eventController.InvokeGameEndedEvent(me);
    }
    public void ShowEndScreen()
    {
        if (GlobalVariables.LevelFailed)
            FailScreen.SetActive(true);
        else
            LevelClearScreen.SetActive(true);
    }

    public void DirectScene(string targetScene)
    {
        SceneManager.LoadScene(targetScene);
    }
    public void QuitApp()
    {
        Application.Quit();
    }
}
