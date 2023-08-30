using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        //skrypt interakcji monet
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
        if(playerInventory != null)
        {
            playerInventory.CoinCollected();
            gameObject.SetActive(false);
            

        }

    }
    

}
