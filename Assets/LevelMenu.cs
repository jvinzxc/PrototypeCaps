using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    public void OpenLevel(int levelID)
    {
        SceneManager.LoadScene(levelID);
        Time.timeScale = 1;
    }
}
