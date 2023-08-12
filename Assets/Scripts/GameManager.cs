using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject menuPanel;

    public static bool gameStarted = false;

    public void PlayButton()
    {
        gameStarted = true;
        MenuPanel();
    }
    public void MenuPanel()
    {
        if (gameStarted)
        {
            menuPanel.SetActive(false);
        }
        else
        {
            menuPanel.SetActive(true);
        }
    }
}
