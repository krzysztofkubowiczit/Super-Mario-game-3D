using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalScore : MonoBehaviour
{
    //Skrypt do zarz�dzania napisem ilo�ci zdobytych monet w ekranie ko�cowym
    private TextMeshProUGUI coinText;
    private Win win;

    private void Start()
    {
        win = GameObject.FindGameObjectWithTag("Finish").GetComponent<Win>();
       
    }

    public void UpdateCoinText(Win win)
    {
        coinText.text = win.finalScore.ToString();
        
    }
}
