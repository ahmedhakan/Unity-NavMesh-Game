using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseMenu : MonoBehaviour
{
    public GameObject loseMenuUI;

    // This method is called when the player dies
    public void ShowLoseMenu()
    {
        loseMenuUI.SetActive(true); // Activate the lose screen UI panel
        Time.timeScale = 0f; // Freeze the game time
    }
}
