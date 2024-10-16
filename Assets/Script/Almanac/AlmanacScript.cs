using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlmanacScript : MonoBehaviour
{
    public GameObject almanacPanel;

    void Update()
    {
        if (almanacPanel.activeSelf)
        {
            // Pause the game by setting timeScale to 0
            Time.timeScale = 0;
        }
        else
        {
            // Resume the game by setting timeScale back to 1
            Time.timeScale = 1;
        }
    }
}
