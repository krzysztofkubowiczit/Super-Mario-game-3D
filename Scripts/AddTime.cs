using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AddTime : MonoBehaviour
{
    // Skrypt do dodawania czasu po wejœciu w zegar
    private TimeManager timeManager;

    public float timeToAdd = 5f;
    private void Start()
    {
        timeManager = GameObject.FindGameObjectWithTag("Canva").GetComponent<TimeManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
      
            timeManager.time += timeToAdd;
            Destroy(this.gameObject);
            
        
    }

}
