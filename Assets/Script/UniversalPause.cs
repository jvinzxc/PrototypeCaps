using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniversalPause : MonoBehaviour
{
    public void PauseTime()
    {
        Time.timeScale = 0;
    }
    public void ResumeTime()
    {
        Time .timeScale = 1;
    }
}
