using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMenu : MonoBehaviour
{
    public GameObject endScreenUI;

    // This method is called when the timer reaches 0
    public void ShowEndScreen()
    {
        endScreenUI.SetActive(true); // Activate the end screen UI panel
        Time.timeScale = 0f; // Freeze the game time
    }
}
