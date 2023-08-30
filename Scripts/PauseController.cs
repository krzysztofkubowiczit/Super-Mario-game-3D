using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PauseController : MonoBehaviour
{
    // Skrypt przeznaczony do robienia pauzy
    public UnityEvent GamePaused;
    public UnityEvent GameResumed;
    private bool isPaused;
    //Skrypt do w��czania pauzy po klikni�ciu P 
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            isPaused = !isPaused;

            if(isPaused)
            {
                Time.timeScale = 0;
                GamePaused.Invoke();
            }
            else
            {
                Time.timeScale = 1;
                GameResumed.Invoke();
            }
        }
    }
}
