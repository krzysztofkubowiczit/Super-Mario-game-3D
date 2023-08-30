using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Win : MonoBehaviour
{
    public int finalScore;
    private PlayerInventory playerInventory;
    // Skrypt ko�cz�cy gr� po wej�ciu do zielonej rury 

    private void Start()
    {
        playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
    }
    private void OnTriggerEnter(Collider other)
    {
        finalScore = playerInventory.NumberOfCoins;
        SceneManager.LoadScene("WinView");
    }
}
