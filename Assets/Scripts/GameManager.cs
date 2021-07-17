using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private EventController _eventController;
    [SerializeField] private Image EndScreen ;
    private void Start()
    {
        if (_eventController == null) _eventController = FindObjectOfType<EventController>();
    }
    public void CheckGameEnd(Transform pin)
    {
        if (pin.GetComponentInChildren<Text>().text == (GlobalVariables.AllPins.Count).ToString())
        {
            Debug.Log("Level Cleared");
        }
    }
    public void GameFailed(Transform me, Transform other)
    {
        _eventController.InvokeGameEndedEvent(me);
    }
    public void ShowEndScreen()
    {
        StartCoroutine(ShowingEndScreen());
    }

    private IEnumerator ShowingEndScreen()
    {
        yield return new WaitForSeconds(.25f);
        float opacity = 0;
        while (true)
        {

        }
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
