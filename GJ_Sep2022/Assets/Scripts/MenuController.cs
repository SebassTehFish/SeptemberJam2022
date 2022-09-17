using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // Index of the main game
    public int gameIndex;

    // Loads game scene
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + gameIndex);
    }

    // For later (if time)
    /*
    public void CreditPage()
    {

    }
    */

    // Quits the application
    public void QuitGame()
    {
        Application.Quit();
    }
}
