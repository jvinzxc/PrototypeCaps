using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialUI : MonoBehaviour
{
    public GameObject tutorials;
    public void Tutorial()
    {
        tutorials.SetActive(true);
        Time.timeScale = 0;
    }
    public void ExitTutorial()
    {
        tutorials.SetActive(false);
        Time.timeScale = 1;
    }
}
