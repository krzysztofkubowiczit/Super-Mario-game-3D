using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    //Skrypt licznika monet
  
    public int NumberOfCoins { get; private set; }
    public UnityEvent<PlayerInventory> OnCoinCollected;

    public void CoinCollected()
    {
        NumberOfCoins++;

        OnCoinCollected.Invoke(this);
    }
}
