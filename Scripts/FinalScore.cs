using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalScore : MonoBehaviour
{
    //Skrypt do zarz¹dzania napisem iloœci zdobytych monet w ekranie koñcowym
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
