using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    //Skrypt s³u¿¹cy do odliczania czasu

    public TextMeshProUGUI timeText;
    public float time;
    
    private void Update()
    {
        time -= Time.deltaTime;
        timeText.text = "Time: " +Mathf.Clamp(Mathf.CeilToInt(time),0,int.MaxValue).ToString();
        if(time <= 0)
        {
            SceneManager.LoadScene("Level 1");
        }
    }
}
