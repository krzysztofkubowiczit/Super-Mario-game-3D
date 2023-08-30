using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class InventoryUI : MonoBehaviour
{
    //Skrypt do zarz¹dzania napisem iloœci zdibytych monet
    private TextMeshProUGUI coinText;
    private AudioSource audioSource;

    private void Start()
    {
        coinText = GetComponent<TextMeshProUGUI>();
        audioSource = GetComponent<AudioSource>();
    }

    public void UpdateCoinText(PlayerInventory playerInventory)
    {
        coinText.text = playerInventory.NumberOfCoins.ToString();
        audioSource.Play();
    }
}
