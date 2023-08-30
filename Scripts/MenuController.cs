using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{
    // Skrypt do zarz¹dzania przyciskami w Menu
    private void Start()
    {
        Cursor.visible = true;
    }
    public void Play()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
