using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialUI : MonoBehaviour
{
    public GameObject tutorials;
    void Start()
    {
        tutorials.SetActive(true);
        Time.timeScale = 0;
    }
}
